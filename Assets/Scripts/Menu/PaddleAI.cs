/*
 * Fecha: 25/02/2023
 * Johan Steven Jimenez Avendaño
 * Script for PaddleAI automatic movement
 * 
 * Description:
 * 
 * 
 * Autonomous movement of the paddle based on distance and Circle Collider 2D check to determine 
 * if the ball is within its range and move. At the same time, the movement of this object 
 * is locked in the X and Y axis up to a certain range to avoid exaggerated movements.
 *
 * This code can be used for Player vs. AI.
 * 
 */




using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    [SerializeField] private float speed = 7f;  // The speed at which the paddle moves
    private float yBound = 3.75f;             // The upper and lower limits in the Y-axis for the paddle
    Vector2 paddlePose;                       // The current position of the paddle
    public GameObject ballPosition;           // The ball that will follow the paddle
    bool rangeStatus;                         // Whether the ball is within the paddle's detection range
    private Vector3 previousPosition;         // The previous position of the paddle
    [SerializeField] private float rangeDetection = 7f; // The range of detection of the paddle

    private void Start()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (rangeStatus)
        {
            Vector3 paddlePosition = transform.position;
            Vector3 ballPositionn = ballPosition.transform.position;
            // Limit the position of the paddle in the Y-axis based on the current position of the ball and the defined limits
            float newYPosition = Mathf.Clamp(paddlePosition.y + (ballPositionn.y - paddlePosition.y) * speed * Time.deltaTime, -yBound, yBound);
            // Assign the previous position of the paddle in the X-axis so it doesn't move in that axis
            transform.position = new Vector3(previousPosition.x, newYPosition, 0);
        }

        // If the distance between the current position of the paddle and the current position of the ball is greater than 7, set rangeStatus to false
        if (Vector2.Distance(transform.position, paddlePose) > rangeDetection)
        {
            rangeStatus = false;
        }
    }

    // If the ball is within the paddle's detection range, update paddlePose and set rangeStatus to true
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ball"))
        {
            paddlePose = ballPosition.transform.position;
            rangeStatus = true;
        }
    }
}
