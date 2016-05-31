using UnityEngine;
using System.Collections;

public class AwanDisappear : MonoBehaviour {
    public float delay;
    public float incMove;
    public bool moveRight;
    private bool isDoneMove = false;
    private bool isDoneWait = false;
    private float destination = 15;
	// Use this for initialization
	void Start () {
        if (!moveRight) {
            destination *= -1;
            incMove *= -1;
        }
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(waitAndMove());
	}

    IEnumerator waitAndMove() {
        if (!isDoneWait) {
            yield return new WaitForSeconds(delay);
            isDoneWait = true;
        }
        move();
    }

    void move() {
        if (!isDoneMove) {
            transform.position = new Vector2(transform.position.x + incMove, transform.position.y);
            if (transform.position.x >= 15) {
                isDoneMove = true;
            }
        }
    }
}
