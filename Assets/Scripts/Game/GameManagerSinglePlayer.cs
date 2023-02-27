using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class GameManagerSinglePlayer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI paddle1ScoreText;
    [SerializeField] private TextMeshProUGUI paddle2ScoreText;

    public Transform paddle1Transform;
    public Transform paddle2Transform;
    [SerializeField] private Transform ballTransform;

    public PaddleAI paddleAI;
    public int paddle1Score;
    int paddle2Score;

    private static GameManagerSinglePlayer instance;

    public static GameManagerSinglePlayer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManagerSinglePlayer>();
            }
            return instance;
        }
    }

    public void Paddle1Scored()
    {
        paddle1Score++;
        paddleAI.speed += 1;
        paddle1ScoreText.text = paddle1Score.ToString();
    }

    public void Paddle2Scored()
    {
        paddle2Score++;
        paddle2ScoreText.text = paddle2Score.ToString();
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
