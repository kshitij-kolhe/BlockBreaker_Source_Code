using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 0;
    [SerializeField] float yPush = 0;
    [SerializeField] AudioClip[] audioClip;
    [SerializeField] float randomTweak = 0;

    Vector2 difference;
    bool hasStarted = false;

    void Start()
    {
        difference = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClicked();
        }

    }

    private void LaunchOnMouseClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
        
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);

        transform.position = paddlePosition + difference;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomTweak), UnityEngine.Random.Range(0f, randomTweak));  

        if (hasStarted)
        {
            AudioClip clip = audioClip[UnityEngine.Random.Range(0, audioClip.Length)];

            GetComponent<AudioSource>().PlayOneShot(clip);
            GetComponent<Rigidbody2D>().velocity += velocityTweak;
        }

    }
}
