using UnityEngine;
using System.Collections;

public class narasiControllet5 : MonoBehaviour {
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void changeNarasi() {
        Debug.Log("child count = " + transform.childCount);
        //transform.GetChild(0).gameObject.GetComponent<ObjFade>().startFade();
        for(int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.GetComponent<ObjFade>().startFade();
        }
    }
}
