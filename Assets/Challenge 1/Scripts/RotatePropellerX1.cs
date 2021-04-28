using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropellerX1 : MonoBehaviour
{
    public float rotationSpeed;


    // Update is called once per frame
    void Update()
    {

        // rotate the propeller on the X-axis
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
    }
}
