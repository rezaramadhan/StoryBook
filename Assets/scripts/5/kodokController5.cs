using UnityEngine;
using System.Collections;

public class kodokController5 : MonoBehaviour {
    public float incPosXY;
    public bool isShouldJump = false;
	private AudioSource jumpSFX;
    // Use this for initialization
    void Start () {
		jumpSFX = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (isShouldJump) {
            jump();
        }
    }

    void jump() {
		jumpSFX.Play ();
        Vector2 currentPos = transform.position;
        transform.position = new Vector2(currentPos.x + incPosXY, currentPos.y + incPosXY);
        if (transform.position.x >= 15) {
            isShouldJump = false;
            GameObject.Find("gabus1").GetComponent<ikanController5>().isShouldFaint = true;
        }
    }
}
