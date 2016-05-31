using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ripple : MonoBehaviour {
    public string changeLevel;
	private int waveNumber;
	public float distanceX, distanceZ;
	public float[] wave;
	public float magnitude;
	public Vector2[] impactPos;
	public float[] distance;
	public float speed;
	public float maxDelay;
	private int counter;
	Mesh m;
	Renderer r;
	// Use this for initialization
	void Start () {
		m = GetComponent<MeshFilter> ().mesh;
		r = GetComponent<Renderer> ();
		counter = 0;
	}

	// Update is called once per frame
	void Update () {
		counter++;
		for (int i = 0; i < 4; i++) {
			wave [i] = wave[i] * 0.95f;
			if (wave [i] > 0) {
				distance [i] += speed;
				r.material.SetFloat ("_Wave" + (i + 1), wave [i]);
				r.material.SetFloat ("_Distance" + (i + 1), distance [i]);
			}
			if (wave [i] < 0.01) {
				distance [i] = 0;
				r.material.SetFloat ("_Wave" + (i + 1), 0);
				wave [i] = 0;
			}
		}
		if (counter > maxDelay) {
			SceneManager.LoadScene (changeLevel);
		}
	}

	void  OnMouseDown() {
		float x = Camera.main.ScreenToWorldPoint (Input.mousePosition).x;
		float z = Camera.main.ScreenToWorldPoint (Input.mousePosition).z;
		Debug.Log ("Here X" + Input.mousePosition.x + " Y" + Input.mousePosition.y + " Z" + Input.mousePosition.z + "" +
			"relative X" + x +" z"+ z + " time " + Time.deltaTime);
		waveNumber++;
		if (waveNumber == 5) {
			waveNumber = 1;
		}
		wave [waveNumber - 1] = 0;
		distance [waveNumber - 1] = 0;

		//distanceX = this.transform.position.x - x;
		//distanceZ = this.transform.position.z - z;
		distanceX = impactPos [waveNumber - 1].x = x;
		distanceZ = impactPos [waveNumber - 1].y = z;

		r.material.SetFloat ("_xImpact" + waveNumber, impactPos[waveNumber-1].x);
		r.material.SetFloat ("_zImpact" + waveNumber, impactPos[waveNumber-1].y);


		r.material.SetFloat ("_OffsetX" + waveNumber, distanceX/m.bounds.size.x * 15f);
		r.material.SetFloat ("_OffsetZ" + waveNumber, distanceZ/m.bounds.size.z * 15f);

		r.material.SetFloat ("_Wave" + waveNumber, magnitude);
		wave [waveNumber - 1] = magnitude;
	}
}
