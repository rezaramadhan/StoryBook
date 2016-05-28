using UnityEngine;
using System.Collections;

public class MoveHere : MonoBehaviour {
	public GameObject tupai;
	public GameObject panah;
	public float moveSpeed;
	private bool startMove = false;
	private Vector3 moveTo;
	private Vector3 currentPos;
	private Vector3 delta;
	private Vector3 endPos;
	private Vector3 midPos;
	//private bool enableClick = false;
	// Use this for initialization
	void Start () {
		endPos = transform.position;
		endPos.y += 1.1f;
		currentPos = tupai.transform.position;
		moveTo = currentPos -endPos;
	}
	
	// Update is called once per frame
	void Update () {
		if (startMove) {
			Debug.Log ("Moving" + tupai.transform.position + "" +currentPos);
			currentPos -= moveTo * moveSpeed;
			tupai.transform.position = currentPos;
			delta = currentPos - endPos;
			if (Mathf.Abs(delta.x) < 0.05 && Mathf.Abs(delta.y) < 0.05) {
				Debug.Log ("end");
				startMove = false;
				tupai.transform.position = endPos;
			}
		}
	}

	void OnMouseDown() {
		Debug.Log ("Clicked");
		startMove = true;
		panah.GetComponent<FadeAndMoveUpDown> ().fadeOut = true;
	}

}