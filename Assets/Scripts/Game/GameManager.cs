using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : NetworkBehaviour
{

    public Transform paddle1Transform;
    public Transform paddle2Transform;
    [SerializeField] private Transform ballTransform;

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public void Restart()
    {
        paddle1Transform.position = new Vector2(paddle1Transform.position.x, 0);
        paddle2Transform.position = new Vector2(paddle2Transform.position.x, 0);
        ballTransform.position = new Vector2(0, 0);
    }

    public void StartGame()
    {
        paddle1Transform = GameObject.Find("paddle 1").transform;
        paddle2Transform = GameObject.Find("paddle 2").transform;
    }
}
