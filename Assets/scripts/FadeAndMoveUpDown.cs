using UnityEngine;
using System.Collections;

public class FadeAndMoveUpDown : MonoBehaviour {
	private Color currentColor;
	private Renderer r;
	public float fadeSpeed;
	public float moveSpeed;
	public GameObject moveHere;

	private Vector3 startPos;
	private Vector3 endPos;
	private Vector3 currentPos;
	private Vector3 delta;
	private bool isMoveUp = false;

	private bool startFade = true;
	private bool startMove = false;
	public bool fadeOut = false;

	void Start () {
		r = GetComponent<Renderer> ();
		currentColor = r.material.color;
		currentColor.a = 0f;
		r.material.color = currentColor;

		endPos = currentPos = startPos = transform.position;
		endPos.y = endPos.y - 0.75f;
		Debug.Log (startPos + " " +endPos);
	}
	
	// Update is called once per frame
	void Update () {
		if (startFade) {
			FadeIn ();
		}

		if (fadeOut) {
			FadeOut ();
		}
		if (startMove) {
			Move ();
			moveHere.SetActive (true);
		}
	}

	void FadeOut() {
		currentColor.a -= 1 * Time.deltaTime * fadeSpeed;
		if (currentColor.a >= 0) {
			r.material.color = currentColor;
		} else {
			fadeOut = false;
		}
	}

	void FadeIn() {
		currentColor.a += 1 * Time.deltaTime * fadeSpeed;
		if (currentColor.a <= 1) {
			r.material.color = currentColor;
		} else {
			startFade = false;
			startMove = true;
		}
	}

	void Move() {
		if (isMoveUp) {
			delta = currentPos - startPos;
			//Debug.Log ("Move up, delta" + delta);
		} else {
			delta = currentPos - endPos;
			//Debug.Log ("Move down, delta" +delta);
		}	

		currentPos.y -= moveSpeed;
		transform.position = currentPos;
		if (Mathf.Abs(delta.y) <= 0.05) {
			isMoveUp = !isMoveUp;
			moveSpeed = -moveSpeed;
		}
		/*if (isMoveUp) {
			if (currentPos.y <= startPos.y) {
				transform.position = currentPos;
			} else {
				isMoveUp = !isMoveUp;
			}
		} else {
			if (currentPos.y >= endPos.y) {
				transform.position = currentPos;
			} else {
				isMoveUp = !isMoveUp;
			}
		} */
	}
}
