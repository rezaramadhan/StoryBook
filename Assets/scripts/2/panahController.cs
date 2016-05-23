using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class panahController : MonoBehaviour {
    //public float duration;
    public float deltaFade;
    public float deltaMove;
    public float incMove;
    public bool isFadeIn;
    public bool startFade = false;
    public bool isDoneFade = false;
    public float minSwipeDistY;

    private Vector2 startTouchPos;
    private Vector2 endTouchPos;
    private bool isTouched = false;
    private bool isMoveDown = true;
    private GameObject panah;
    private Color colorStart;
    private Color colorEnd;
    private Vector2 startPos;
    private Vector2 endPos;
	// Use this for initialization
	void Start () {
        Debug.Log("START");
        startPos = new Vector2(transform.position.x, transform.position.y);
        endPos = new Vector2(startPos.x, startPos.y - deltaMove);
        colorStart = GetComponent<Renderer>().material.color;
        colorEnd = new Color(colorStart.r, colorStart.g, colorStart.b, 0.0f);
        if (isFadeIn) {
            GetComponent<Renderer>().material.color = colorEnd;
        }
    }

    void Update() {
        if (isTouched) {
            Debug.Log("Touched");
            //GameObject.Find("narasi").GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
        }
        checkSwipe();
        if (isDoneFade) {
            move();
        }
        if (startFade)
        {
            if (isFadeIn)
            {
                fadeIn();
            }
            else
            {
                fadeOut();
            }
        }
    }
    private void checkSwipe() {
        RaycastHit2D hit;
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject.name == transform.name && isDoneFade) {
                Debug.Log("Touched");
                isTouched = true;
                startTouchPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
        }
        if (Input.GetMouseButtonUp(0)) {
            Debug.Log("RELEASED");
            if (isTouched) {
                isTouched = false;
                endTouchPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                float swipeDistVertical = startTouchPos.y - endTouchPos.y;
                //float swipeDistVertical = ((new Vector3(0, endTouchPos.y, 0)) - new Vector3(0, endTouchPos.y, 0)).magnitude;
                Debug.Log("SWIPE DIST = " + swipeDistVertical);
                GameObject.Find("narasi").GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);

                if (swipeDistVertical > minSwipeDistY) {
                    GameObject.Find("narasi").GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
                    SceneManager.LoadScene("4");
                } else {
                    Debug.Log("not enough");
                }
            }
        }
    }
    public void fadeOut()
    {
        float currentAlpha = GameObject.Find("panah").GetComponent<Renderer>().material.color.a;
        if (currentAlpha > colorEnd.a) {
            currentAlpha -= deltaFade;
            GetComponent<Renderer>().material.color = new Color(colorStart.r, colorStart.g, colorStart.b, currentAlpha);
        } else {
            GetComponent<Renderer>().material.color = colorEnd;
            startFade = false;
            isDoneFade = true;
        }
    }
    public void fadeIn()
    {
        float currentAlpha = GameObject.Find("panah").GetComponent<Renderer>().material.color.a;
        if (currentAlpha < colorStart.a) {
            currentAlpha += deltaFade;
            GetComponent<Renderer>().material.color = new Color(colorStart.r, colorStart.g, colorStart.b, currentAlpha);
        } else {
            GetComponent<Renderer>().material.color = colorStart;
            startFade = false;
            isDoneFade = true;
        }
    }
    public void move() {

        if (isMoveDown) {
            transform.position = new Vector2(transform.position.x, transform.position.y - incMove);
            if (transform.position.y <= endPos.y) {
                transform.position = endPos;
                isMoveDown = false;
            }
        } else {
            transform.position = new Vector2(transform.position.x, transform.position.y + incMove);
            if (transform.position.y >= startPos.y) {
                transform.position = startPos;
                isMoveDown = true;
            }
        }
    }
}
