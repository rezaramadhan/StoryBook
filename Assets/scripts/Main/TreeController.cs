using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour {
	public float speed;
	private bool move = false;
	private int countMove = 0;
	public int maxMove;
	public GameObject leaf;
	public int nLeaf;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit;
		if (Input.GetMouseButtonDown (0)) {
			hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			if (hit.collider != null && hit.transform.gameObject.tag=="Tree") {
				//Debug.Log ("TAPPED");
				move = true;
			}
		}

		if (move & countMove < maxMove) {
			var amount = 0.005f; //how much it shakes
			Vector3 v = new Vector3();
			v.x = Mathf.Sin (Time.time* speed);
			//Debug.Log (v);
			transform.position += v*amount;
			countMove++;
			Vector3 spawnPos = new Vector3 (-6, 6, 0);
			if (countMove % 15 == 0) {
				for (int i = 1; i <= 2; i++){
					spawnPos.x = (float)( Random.value * (9.0 - (-7.5)) - 9.5);
					Instantiate (leaf, spawnPos, transform.rotation);
				}
			}
		}

		if (countMove == maxMove) {
			move = false;
			countMove = 0;
		}

	}
}
