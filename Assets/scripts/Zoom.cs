using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour {
    public float zoomIncrement;
    public float maxScale;
    public float minScale;
    public bool isDoneZooming = false;
    // Update is called once per frame
    void Update()
    {
        zoom(zoomIncrement);
    }

    void zoom(float increment)
    {
        float currentScale = transform.localScale.x;
        //Debug.Log(currentScale);

        currentScale += increment;
        if (currentScale >= maxScale)
        {
            currentScale = maxScale;
            isDoneZooming = true;
        }
        else if (currentScale <= minScale)
        {
            currentScale = minScale;
            isDoneZooming = true;
        }
        transform.localScale = new Vector2(currentScale, currentScale);
    }
}
