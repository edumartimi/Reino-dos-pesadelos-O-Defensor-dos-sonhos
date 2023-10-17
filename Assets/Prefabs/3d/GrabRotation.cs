using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRotation : MonoBehaviour
{
    float RotationSpeed = 1f;
    public Camera Analise_Cam;
    public float zoomSpeed = 5.0f;
    public float maxFOV = 80.0f;
    public float minFOV = 10.0f;

    private void OnMouseDrag()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * RotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * RotationSpeed;

        transform.Rotate(Vector3.up, XaxisRotation);
        transform.Rotate(Vector3.right, YaxisRotation);
    }

    public float ZoomSpeed
    {
        get { return zoomSpeed; }
        set { zoomSpeed = value; }
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            float newFOV = Analise_Cam.fieldOfView - scroll * zoomSpeed;
            newFOV = Mathf.Clamp(newFOV, minFOV, maxFOV);
            Analise_Cam.fieldOfView = newFOV;
        }


        
    }
}
