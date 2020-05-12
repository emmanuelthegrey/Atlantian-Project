using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactRotate : MonoBehaviour
{
    public float speed = .8f;
    public float zoomSpeed = 1.5f;

    int minFieldOfView = 14;
    int maxFieldOfView = 25;

    Vector3 lastMousePos;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.fieldOfView = maxFieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.left, Input.GetAxis("Vertical") * speed);
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.up, Input.GetAxis("Horizontal") * speed);
        }

        if (Input.GetMouseButton(0))
        {
            transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.up, (lastMousePos.x - Input.mousePosition.x) * speed);
            transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.left, (lastMousePos.y - Input.mousePosition.y) * speed);
        }

        if (Input.mouseScrollDelta.y != 0)
        {
            Camera.main.fieldOfView -= Input.mouseScrollDelta.y * zoomSpeed;

            if (Camera.main.fieldOfView > maxFieldOfView)
            {
                Camera.main.fieldOfView = maxFieldOfView;
            }
            if (Camera.main.fieldOfView < minFieldOfView)
            {
                Camera.main.fieldOfView = minFieldOfView;
            }
        }

        lastMousePos = Input.mousePosition;
    }
}
