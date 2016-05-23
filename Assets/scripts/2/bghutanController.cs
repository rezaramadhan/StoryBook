using UnityEngine;
using System.Collections;

public class bghutanController : MonoBehaviour {	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Zoom>().isDoneZooming)
        {
            GameObject.Find("panah").GetComponent<panahController>().startFade = true;
        }
	}
}
