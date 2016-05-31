using UnityEngine;
using System.Collections;

public class SunMoveUp : MonoBehaviour {

    public float delay;
    public float incMove;
    private bool isDoneMove = false;
    private bool isDoneWait = false;
    private float destination = 15;
    // Use this for initialization
    void Start() {
       
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
            transform.position = new Vector2(transform.position.x, transform.position.y + incMove);
            if (transform.position.y >= -0.5) {
                isDoneMove = true;
            }
        }
    }
}
