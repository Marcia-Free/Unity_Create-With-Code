using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCH4 : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed = 5.0f;

    private float powerupStrength = 30.0f;
    public bool hasPowerup;

    public GameObject powerupIndicator;
    private GameManagerCH4 gameManager;



    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerCH4>();
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");

        if (playerRb.transform.position.y > 0 && playerRb.transform.position.y < 1)
        {
            playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
            playerRb.AddForce(focalPoint.transform.right * rotateInput * speed);
        }

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);


        if (playerRb.transform.position.y < -8)
        {
            gameManager.GameOver();
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            //Debug.Log("Player collided with " + collision.gameObject + "with powerup set to " + hasPowerup);
        }
    }


}
