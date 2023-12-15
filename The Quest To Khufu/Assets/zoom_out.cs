using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom_out : MonoBehaviour
{
    private Camera cam;
    public float zoomedInSize = 4f; // Specify the zoomed-in size
    public float zoomedOutSize = 8f; // Specify the zoomed-out size
    public float zoomSpeed = 5f;
    public KeyCode zoomOutButton = KeyCode.Space; // Change this to the desired key

    private bool isZoomedOut = false;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = zoomedInSize;
    }

    void Update()
    {
        if (Input.GetKeyDown(zoomOutButton) && !isZoomedOut)
        {
            StartCoroutine(ZoomOutAndIn());
        }
    }

    IEnumerator ZoomOutAndIn()
    {
        isZoomedOut = true;

        // Zoom Out
        float elapsedTime = 0f;
        while (elapsedTime < 1f) // Zoom out for 1 second (adjust as needed)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomedOutSize, Time.deltaTime * zoomSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Wait for the specified zoomed-out time
        yield return new WaitForSeconds(1f); // Adjust as needed

        // Zoom In
        elapsedTime = 0f;
        while (elapsedTime < 1f) // Zoom in for 1 second (adjust as needed)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomedInSize, Time.deltaTime * zoomSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isZoomedOut = false;
    }
}
