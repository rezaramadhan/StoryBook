using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnableNext : MonoBehaviour {
	public GameObject next;
	public GameObject tupai;
	public bool isNextScene;
	public string nextScene;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
		//Debug.Log ("called" + tupai.transform.position +" " + transform.position);
		if (isCloseEnough ()) {
			//Debug.Log ("close");
			if (isNextScene) {
				SceneManager.LoadScene (nextScene);
			} else {
				next.SetActive (true);
			}
		}
	}

	bool isCloseEnough() {
		return (Mathf.Abs(tupai.transform.position.x - transform.position.x) < 0.05 &&
			Mathf.Abs(tupai.transform.position.y - transform.position.y) < 0.05 + 1.1f);
	}
}
