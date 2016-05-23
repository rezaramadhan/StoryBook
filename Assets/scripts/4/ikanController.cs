using UnityEngine;
using System.Collections;

public class ikanController : MonoBehaviour {
    public float incMoveX;
    public float threshold;
    private Vector2 currentPos;
    private Vector2 startPos;
    private Vector2 endPos;
    private bool isClicked = false;
    private bool isShouldMove = false;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        checkClicked();
        if(isClicked) {
            Vector3 touchpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(touchpos.x,touchpos.y);
            if(Input.GetMouseButtonUp(0)) {
                endPos = new Vector2(touchpos.x, touchpos.y);
                isClicked = false;
                Debug.Log(endPos.x);
                if (endPos.x > threshold) {
                    Debug.Log("MOVE!");
                    isShouldMove = true;
                }
                transform.position = startPos;
            }
        }
        if (isShouldMove) {
            moveIkan();
        }
        if (transform.position.x > 10) {
            //pindah scene
        }
	}

    void moveIkan() {
        currentPos = transform.position;
        transform.position = new Vector2(currentPos.x + incMoveX, currentPos.y);
    }

    void checkClicked() {
        RaycastHit2D hit;
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject.name == transform.name) {
                isClicked = true;
            }
        }
    }
}
