using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraCH4 : MonoBehaviour
{
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetMouseButton(0))
        {
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }

}
