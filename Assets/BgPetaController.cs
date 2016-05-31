using UnityEngine;
using System.Collections;

public class BgPetaController : MonoBehaviour {
	public bool isSecondLoad = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (isSecondLoad) {
			transform.position.Set (transform.position.x, transform.position.y, 0);
			Debug.Log ("SECOND LOAD");
		}
	}
}
