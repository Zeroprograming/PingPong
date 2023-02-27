using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.WSA;

public class BallMultiplayer : NetworkBehaviour
{

    NetworkVariable<int> countPlayer = new NetworkVariable<int>();

    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float velocityMultiplier = 1.1f;
    private Rigidbody2D ballRb;
    public bool condicion = false;

    public scoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        ballRb= GetComponent<Rigidbody2D>();
        StartCoroutine(CountToLaunch());
      
    }

    private IEnumerator CountToLaunch()
    {
        yield return new WaitForSeconds(1);
        condicion= true;
    }

    private void Update()
    {
        if (condicion)
        {
            if (IsServer)
            {
                if (NetworkManager.Singleton.ConnectedClients.Count == 2)
                {
                    GameManager.Instance.StartGame();
                    LaunchClientRpcc();
                    condicion = false;
                }
            }
            else { return; }
            
        }
    }

    //[ClientRpc]
    private void LaunchClientRpcc()
    {
        float xVelocity = Random.Range(0,2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity,yVelocity) * initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Paddle"))
        {
            ballRb.velocity *= velocityMultiplier;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Goal1"))
        {
            scoreManager.Paddle2Scored();
            GameManager.Instance.Restart();
            LaunchClientRpcc();
        }
        if(collision.gameObject.CompareTag("Goal2"))
        {
            scoreManager.Paddle1Scored();
            GameManager.Instance.Restart();
            LaunchClientRpcc();
        }
    }
   
}
