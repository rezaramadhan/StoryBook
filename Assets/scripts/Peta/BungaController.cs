using UnityEngine;
using System.Collections;

public class BungaController : MonoBehaviour {
	public float finalSize;
	public GameObject tupai;

	private bool isClicked = false;
	private bool isZoom = true;
	private bool isMoveOrigin = true;
	private AudioSource a;
	private Vector3 endScale;
	private Vector3 deltaScale;
	private Vector3 currentScale;
	private Vector3 currentPos;
	private Vector3 endPos;
	private Vector3 deltaPos;
	private Rigidbody2D r;
	private float x;
	private float y;
	private float z;

	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody2D> ();
		a = GetComponent<AudioSource> ();
		currentScale = transform.localScale;
		endScale = new Vector3 (finalSize, finalSize, finalSize);
		deltaScale = transform.localScale - endScale;
		currentPos = transform.position;
		endPos = new Vector3 (0f,0f,-4.2f);
		deltaPos = transform.position - endPos;
		Debug.Log (deltaPos + " " + deltaScale);

		x = (Random.value + 1)*60;
		y = (Random.value + 1)*60;
		z = (Random.value * 4 + 1)*60;
	}
	
	// Update is called once per frame
	void Update () {
		if (isClicked) {
			//transform.position.Set(transform.position.x, transform.position.y, -4.5f);
			if (isZoom) {
				Zoom ();
			}
			if (isMoveOrigin) {
				MoveOrigin();
			}
			if (!isZoom && !isMoveOrigin) {
				currentPos.y -= Time.deltaTime * 5;
				transform.position = currentPos;
				transform.Rotate (new Vector3 (x, y, z) * Time.deltaTime);
			}

			if (transform.position.y < -10) {
				Destroy (gameObject);
				tupai.GetComponent<checkFinished> ().nClicked++;
			}
		}
	}

	void OnMouseDown() {
		isClicked = true;
		a.Play ();
		//Debug.Log ("size" + transform.localScale);
	}

	void MoveOrigin (){
		currentPos -= deltaPos * Time.deltaTime;
		transform.position = currentPos;

		if (Mathf.Abs (currentPos.y - endPos.y) < 0.05 && Mathf.Abs (currentPos.x - endPos.y) < 0.05) {
			transform.position = endPos;
			isMoveOrigin = false;
		}
	}

	void Zoom () {
		Debug.Log ("now" + currentPos + " end" + endScale);
		currentScale -= deltaScale * Time.deltaTime;
		transform.localScale = currentScale;

		if (Mathf.Abs (currentScale.y - endScale.y) < 0.005) {
			transform.localScale = endScale;
			isZoom = false;
		}
	}
}
