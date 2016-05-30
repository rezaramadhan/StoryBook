using UnityEngine;
using System.Collections;

public class JejakController : MonoBehaviour {
	public GameObject jejakAktif;
	public GameObject jejakNonAktif;
	public GameObject next;

	//private bool isDragged = false;
	//private bool triggered = false;

	//private bool isOutFromJejak = false;
	// Use this for initialization
	void Start () {
		next.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		/*if (isDragged) {
			Debug.Log (Input.mousePosition);
			if (isKeluar()) {
				isOutFromJejak = true;
			}
		} else {
		
		}

		if (triggered) {
			Debug.Log ("Triggered");

		}*/
	}

	void OnMouseDown() {
		Debug.Log ("clicked");
		//isDragged = true;
		jejakNonAktif.SetActive (false);
		jejakAktif.SetActive (true);
		next.SetActive (true);	

	}

	void OnMouseUp() {
		Debug.Log ("Released");
		//isDragged = false;
	}
}
