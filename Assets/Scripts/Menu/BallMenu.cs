/*
 * Date: 25/02/2023
 * Author: Johan Steven Jimenez Avendaño
 * Ball control script in the menu
 * 
 * Description:
 * 
 * This script controls the behavior of the ball in the menu scene. It includes the following variables:
 * - `initialVelocity`: the initial velocity of the ball.
 * - `velocityMultiplier`: the velocity multiplier applied to the ball when it collides with a paddle.
 * - `ballRb`: the Rigidbody2D component of the ball.
 * 
 * The script includes the following methods:
 * - `Launch()`: launches the ball in a random direction.
 * - `OnCollisionEnter2D()`: when the ball collides with a paddle, increases its velocity.
 * - `OnTriggerEnter2D()`: when the ball enters a goal, resets the paddles and the ball to their starting positions by calling the `Restart()` method of the `MenuManager` singleton instance, and launches the ball again using the `Launch()` method.
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class BallMenu : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;   // The initial velocity of the ball
    [SerializeField] private float velocityMultiplier = 1.1f;  // The velocity multiplier applied to the ball when it collides with a paddle
    private Rigidbody2D ballRb;                            // The Rigidbody2D component of the ball

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();           // Get the Rigidbody2D component of the ball
        Launch();                                      // Launch the ball
    }

    // Launch the ball in a random direction
    private void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }

    // When the ball collides with a paddle, increase its velocity
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            ballRb.velocity *= velocityMultiplier;
        }
    }

    // When the ball enters a goal, reset the paddles and the ball to their starting positions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal1"))
        {
            MenuManager.Instance.Restart();
            Launch();
        }
        if (collision.gameObject.CompareTag("Goal2"))
        {
            MenuManager.Instance.Restart();
            Launch();
        }
    }
}

