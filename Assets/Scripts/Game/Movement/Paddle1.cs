using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle1 : MonoBehaviour
{
    [SerializeField]private float speed = 7f;

    private float yBound = 3.75f;

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxisRaw("Vertical");
        // transform.position += new Vector3(0, movement * speed * Time.deltaTime, 0);

        Vector2 paddlePosition= transform.position;
        paddlePosition.y = Mathf.Clamp(paddlePosition.y + movement * speed * Time.deltaTime, -yBound, yBound);
        transform.position = paddlePosition;
    }
}
