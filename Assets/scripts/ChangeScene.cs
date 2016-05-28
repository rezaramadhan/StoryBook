using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
    public string changeLevel;
    public string namePressed;
    void OnMouseDown()
    {
        SceneManager.LoadScene(changeLevel);

    }
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit;
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.transform.gameObject.name);
            }
            if (hit.collider != null && hit.transform.gameObject.name == namePressed)
            {
                ChangeLevel();
                SceneManager.LoadScene(changeLevel);
            }
        }
    }

    IEnumerator ChangeLevel()
    {
        Debug.Log("CHANGE");
        float fadeTime = GameObject.Find("background").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
    }
}
