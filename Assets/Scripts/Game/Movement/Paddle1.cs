using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.Netcode;
using UnityEngine;

public class Paddle1 : MonoBehaviour
{
    [SerializeField]private float speed = 7f;

    private float yBound = 3.75f;

    private void Start()
    {

        this.gameObject.name = "paddle 1";
        transform.position = new Vector3(7.5f,0f,0f);
       
    }



    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(0, movement * speed * Time.deltaTime, 0);


        Vector2 paddlePosition = transform.position;
        paddlePosition.y = Mathf.Clamp(paddlePosition.y + movement* Time.deltaTime, -yBound, yBound);
        transform.position = paddlePosition;
    }

}
