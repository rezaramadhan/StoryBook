using UnityEngine;
using System.Collections;

public class LeafRotator : MonoBehaviour {
	private float x;
	private float y;
	private float z;
	private float forceX;
	// Update is called once per frame
	Rigidbody2D rb;
	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		forceX = (Random.value * 3 + 1)*50;
		rb.AddForce (new Vector2 (forceX, 0));
		x = (Random.value * 8 + 1)*60;
		y = (Random.value * 8 + 1)*60;
		z = (Random.value * 8 + 1)*60;
	}
	void Update () {
		transform.Rotate (new Vector3 (x, y, z) * Time.deltaTime);

		if (transform.position.y < -5.75)
			Destroy (gameObject);
	}
}
