using UnityEngine;
using System.Collections;

public class FadeBG : MonoBehaviour {

    public float delay;
    // Update is called once per frame
    void Update() {
        StartCoroutine(waitAndFade());
    }

    IEnumerator waitAndFade() {
        yield return new WaitForSeconds(delay);
        transform.GetComponent<ObjFade>().startFade();
    }
}
