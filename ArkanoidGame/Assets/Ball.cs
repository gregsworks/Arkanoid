using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush;
    [SerializeField] float yPush;
    [SerializeField] bool hasStarted = false;
    [SerializeField] Rigidbody2D rb;
    Vector2 paddleToBallVector;
    [SerializeField] Transform explosion;
    public GameManager GameManager;

    private void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }


    private void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchToPaddle();
        }
    }
    

    private void LaunchToPaddle()
    {
          if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rb.simulated = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Block"))
        {
            Transform newExplosion = Instantiate (explosion, collision.transform.position, collision.transform.rotation);
            Destroy (newExplosion.gameObject, 2.5f);
            Destroy (collision.gameObject);
        }
    }
}
