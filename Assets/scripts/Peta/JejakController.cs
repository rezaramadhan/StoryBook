using UnityEngine;
using System.Collections;

public class JejakController : MonoBehaviour {
	public GameObject jejakAktif;
	public GameObject jejakNonAktif;
	public GameObject next;

	private bool isDragged = false;
	private bool triggered = false;

	private bool isOutFromJejak = false;

	// Use this for initialization
	void Start () {
		next.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (isDragged) {
			Debug.Log (Input.mousePosition);
			if (isKeluar()) {
				triggered = true;
				//Debug.Log ("true");
			}
		}

		if (triggered) {
			//Debug.Log ("Triggered");
			jejakNonAktif.SetActive (false);
			jejakAktif.SetActive (true);
			next.SetActive (true);	
		}
	}

	void OnMouseDown () {
		Debug.Log ("clicked");
		isDragged = true;
	}

	void OnMouseUp() {
		Debug.Log ("Released");
		isDragged = false;
	}

	bool isKeluar () {
		Vector2 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		float dist = Vector2.Distance (mouse, transform.position);
		//dist -= 300;
		bool retval = Mathf.Abs(dist) > 0.7f;
		Debug.Log (mouse+""+transform.position+""+dist +" "+retval);
		return (retval);
	}
}
