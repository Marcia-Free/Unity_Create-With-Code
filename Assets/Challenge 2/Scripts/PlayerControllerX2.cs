using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX2 : MonoBehaviour
{
    public GameObject dogPrefab;

    public float timeBetweenShots = 1.0f;  // Allow 1 shots every 3 seconds
    private float timestamp;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Time.time >= timestamp && (Input.GetKeyDown(KeyCode.Space)) )
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            timestamp = Time.time + timeBetweenShots;
        }
    }
}
