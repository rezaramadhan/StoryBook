using UnityEngine;
using System.Collections;

public class ikanController5 : MonoBehaviour {

    public float incMoveX;
    public bool isShouldFaint = false;
    public float deltaFaint;
    //public float threshold;
    private Vector2 currentPos;
    private Vector2 startPos;
    private Vector2 endPos;
    private bool isClickDisabled = false;
    private bool isClicked = false;
    private bool isShouldMove = false;
    private bool isHasTouchedKodok = false;
    // Use this for initialization
    void Start() {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        checkClicked();
        if (!isClickDisabled) {
            if (isClicked) {
                Vector3 touchpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector2(touchpos.x, touchpos.y);
                if (Input.GetMouseButtonUp(0)) {
                    /*endPos = new Vector2(touchpos.x, touchpos.y);
                    Debug.Log(endPos.x);
                    if (endPos.x > threshold) {
                        Debug.Log("MOVE!");
                        isShouldMove = true;
                    }*/
                    isClicked = false;
                    transform.position = startPos;
                }
            }
        }
        if (isShouldMove) {
            moveIkan();
        }
        if (transform.position.x > 10) {
            //pindah scene
        }
        if (isShouldFaint) {
            faint();
        }
    }

    void moveIkan() {
        //Debug.Log("Move " + transform.position);
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

    void faint() {
        GameObject.Find("narasi").GetComponent<narasiControllet5>().changeNarasi();
        if (transform.position.y >= startPos.y - deltaFaint) {
            Vector2 currentPos = transform.position;
            transform.position = new Vector2(currentPos.x, currentPos.y - 0.03f);
        } else {
            if (transform.rotation.eulerAngles.x <= 60) {
                Vector2 rotationVector = transform.rotation.eulerAngles;
                rotationVector.x += 2f;
                //Debug.Log("rotate vector = " + transform.rotation.x);
                transform.rotation = Quaternion.Euler(rotationVector);
            } else {
                GameObject.Find("panah").GetComponent<panahController5>().startFade = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("Collide with " + col.gameObject.name);
        if (col.gameObject.name == "kodok") {
            if (!isHasTouchedKodok) {
                isClickDisabled = true;
                //Destroy(col.gameObject);
                isHasTouchedKodok = true;
                transform.position = startPos;
                isShouldMove = true;
            } else {
                isShouldMove = false;
                GameObject.Find("kodok").GetComponent<kodokController5>().isShouldJump = true;
            }
        }
    }
}
