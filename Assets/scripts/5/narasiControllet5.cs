using UnityEngine;
using System.Collections;

public class narasiControllet5 : MonoBehaviour {
    // Use this for initialization
    void Start () {
        Color currentColor = transform.GetChild(0).GetComponent<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void changeNarasi() {
        Debug.Log("child count = " + transform.GetChildCount());
        //transform.GetChild(0).gameObject.GetComponent<ObjFade>().startFade();
        for(int i = 0; i < transform.GetChildCount(); i++) {
            transform.GetChild(i).gameObject.GetComponent<ObjFade>().startFade();
        }
    }
}
