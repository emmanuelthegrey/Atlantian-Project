using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // transform.Rotate(Vector3.up, 1.0f);
            transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.up, 1.0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(Vector3.down, 1.0f);
            transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f), 1.0f);

        }
        else if (Input.GetKey(KeyCode.W))
        {
            //transform.Rotate(Vector3.right, 1.0f);

            transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.right, 1.0f);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            //transform.Rotate(Vector3.left, 1.0f);

            transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.left, 1.0f);

        }
    }
}
