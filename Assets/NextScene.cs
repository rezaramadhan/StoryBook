using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
	private int n = 0;
	private bool isLoaded = false;
	public string nextScene;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		n++;
		if (n >= 25 && !isLoaded) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (nextScene);
		}
	}

}
