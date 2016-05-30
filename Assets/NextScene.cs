using UnityEngine;
using System.Collections;

public class NextScene : MonoBehaviour {
	private int n = 0;

	public string nextScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		n++;
		if (n >= 25)
			UnityEngine.SceneManagement.SceneManager.LoadScene (nextScene);
	}
}
