using UnityEngine;
using System.Collections;
using System;

public class AwanSlideIn : MonoBehaviour {

    public float delay;
    public float incMove;
    public bool fromRight;
    private bool isDoneMove = false;
    private bool isDoneWait = false;
    private float start = 15;
    private float destination;
    // Use this for initialization
    void Start() {
        destination = transform.position.x;
        if (!fromRight) {
            start *= -1;
        } else {
            incMove *= -1;
        }
        transform.position = new Vector2(start, transform.position.y);
    }

    // Update is called once per frame
    void Update() {
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
            //Debug.Log(transform.position);
            if (transform.position.x <= destination + Math.Abs(incMove) &&
                transform.position.x >= destination - Math.Abs(incMove)) {
                transform.position = new Vector2(destination, transform.position.y);
                isDoneMove = true;
            }
        }
    }
}
