using UnityEngine;
using System.Collections;

public class BackFade : MonoBehaviour {
	public GameObject[] g;

	private bool startFade = false;
	private int idx;
	private Renderer r;
	private Color currentColor;
	private float fadeSpeed = 0.7f;

	// Use this for initialization
	void Start () {
		idx = 0;
		SetBg ();
	}

	void SetBg() {
		r = g[idx].GetComponent<Renderer> ();
		currentColor = r.material.color;
        idx++;
	}

	// Update is called once per frame
	void Update () {
		if (startFade) {
			FadeOut ();
		}
	}

	void OnMouseDown() {
		Debug.Log ("a");
		startFade = true;
        if (idx > 11) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Peta");
        }
    }

	void FadeOut() {
		currentColor.a -= 1 * Time.deltaTime * fadeSpeed;
		if (currentColor.a > -0.1) {
			r.material.color = currentColor;
		} else {
			SetBg ();
			startFade = false;
		}
	}
}
