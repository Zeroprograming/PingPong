using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.Netcode;
using UnityEngine;

public class Paddle : NetworkBehaviour
{
    [SerializeField]private float speed = 7f;

    private float yBound = 3.75f;

    private void Start()
    {


        if (IsOwner)
        {
            this.gameObject.name = "paddle 1";
            transform.position = new Vector3(7.5f,0f,0f);


        }
        else
        {
            this.gameObject.name = "paddle 2";
            transform.position = new Vector3(-7.5f, 0f, 0f);

        }
        
    }



    // Update is called once per frame
    void Update()
    {
        if (IsOwner)
        {
            Movement();
        }

        if (!IsServer && IsOwner)
        {
            ServerMovementServerRpc(

                Input.GetAxis("Vertical") > 0,

                Input.GetAxis("Vertical") < 0

            );
        }
    }

    private void Movement()
    {
        float movement = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(0, movement * speed * Time.deltaTime, 0);


        Vector2 paddlePosition = transform.position;
        paddlePosition.y = Mathf.Clamp(paddlePosition.y + movement * Time.deltaTime, -yBound, yBound);
        transform.position = paddlePosition;
    }

    [ServerRpc]
    private void ServerMovementServerRpc(bool up, bool down)
    {

        transform.position += new Vector3(0, (up ? 1 : down ? -1 : 0) * Time.deltaTime);

        Vector2 paddlePosition = transform.position;
        paddlePosition.y = Mathf.Clamp(paddlePosition.y + (up ? 1 : down ? -1 : 0) * speed * Time.deltaTime, -yBound, yBound);
        transform.position = paddlePosition;
    }
}
