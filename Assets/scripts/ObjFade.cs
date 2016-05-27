using UnityEngine;
using System.Collections;

public class ObjFade : MonoBehaviour {
    public float deltaFade;
    public float deltaMove;
    public bool isFadeIn;
    private bool isStartFade = false;
    public bool isDoneFade = false;
    private Color colorStart;
    private Color colorEnd;
    // Use this for initialization
    void Start () {
        colorStart = GetComponent<Renderer>().material.color;
        colorStart = new Color(colorStart.r, colorStart.g, colorStart.b, 1f);   
        colorEnd = new Color(colorStart.r, colorStart.g, colorStart.b, 0.0f);
        if (isFadeIn) {
            GetComponent<Renderer>().material.color = colorEnd;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (isStartFade) {
            if (isFadeIn) {
                fadeIn();
            } else {
                fadeOut();
            }
        }
    }

    public void fadeOut() {
        float currentAlpha = GameObject.Find(transform.name).GetComponent<Renderer>().material.color.a;
        if (currentAlpha > colorEnd.a) {
            currentAlpha -= deltaFade;
            GetComponent<Renderer>().material.color = new Color(colorStart.r, colorStart.g, colorStart.b, currentAlpha);
        } else {
            GetComponent<Renderer>().material.color = colorEnd;
            isStartFade = false;
            isDoneFade = true;
        }
    }
    public void fadeIn() {
        float currentAlpha = GameObject.Find(transform.name).GetComponent<Renderer>().material.color.a;
        if (currentAlpha < colorStart.a) {
            currentAlpha += deltaFade;
            GetComponent<Renderer>().material.color = new Color(colorStart.r, colorStart.g, colorStart.b, currentAlpha);
        } else {
            GetComponent<Renderer>().material.color = colorStart;
            isStartFade = false;
            isDoneFade = true;
        }
    }
    public void startFade() {
        isStartFade = true;
    }
}
