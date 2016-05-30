using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class checkFinished : MonoBehaviour {
	public int nClicked;
	// Use this for initialization
	void Start () {
		nClicked = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (nClicked >= 5) {
			SceneManager.LoadScene ("Peta");
		}
	}
}
