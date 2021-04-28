﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX2 : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    //private float spawnInterval = 4.0f;

    public float minInterval = 3.0f;
    public float maxInterval = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
        Invoke("SpawnRandomBall", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        float ballTiming = Random.Range(minInterval, maxInterval);
        Invoke("SpawnRandomBall", ballTiming);

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }

}