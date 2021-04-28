using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCH4 : MonoBehaviour
{

    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    private GameManagerCH4 gameManager;


    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerCH4>();
    }


    void Update()
    {
        if (transform.position.y < -8)
        {
            gameManager.UpdateScore(10);
            Destroy(gameObject); 
        }
        else if (transform.position.y > -0.2 && transform.position.y < 0)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
        }
    }
}
