using System.Collections;
using UnityEngine;

public class zoomTouch : MonoBehaviour
{
    float MouseZoomSpeed = 15.0f;
    float TouchZoomSpeed = 0.1f;
    public float ZoomMinBound = 0.1f;
    public float ZoomMaxBound = 179.9f;
    public Camera cam;

    // Use this for initialization
    void Start()
    {
        
    }

    void Update()
    {
       
            // Pinch to zoom
            if (Input.touchCount == 2)
            {

                // get current touch positions
                Touch tZero = Input.GetTouch(0);
                Touch tOne = Input.GetTouch(1);
                // get touch position from the previous frame
                Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
                Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

                float oldTouchDistance = Vector2.Distance(tZeroPrevious, tOnePrevious);
                float currentTouchDistance = Vector2.Distance(tZero.position, tOne.position);

                // get offset value
                float deltaDistance = oldTouchDistance - currentTouchDistance;
                Zoom(deltaDistance, TouchZoomSpeed);
            }
        
        



        if (cam.fieldOfView < ZoomMinBound)
        {
            cam.fieldOfView = 0.1f;
        }
        else
        if (cam.fieldOfView > ZoomMaxBound)
        {
            cam.fieldOfView = 179.9f;
        }
    }

    void Zoom(float deltaMagnitudeDiff, float speed)
    {

        cam.fieldOfView += deltaMagnitudeDiff * speed;
        // set min and max value of Clamp function upon your requirement
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, ZoomMinBound, ZoomMaxBound);
    }
}