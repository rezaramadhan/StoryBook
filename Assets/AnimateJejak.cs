using UnityEngine;
using System.Collections;

public class AnimateJejak : MonoBehaviour {
	public GameObject[] on;
	public GameObject[] off;
	private int idx = 0;
	private int counter = 0;
	private bool end = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter > 10 && !end) {
			on [idx].SetActive (true);
			off [idx].SetActive (false);

			idx++;
			counter = 0;
			if (idx >= on.Length) {
				end = true;
			}
		}
	}
}
