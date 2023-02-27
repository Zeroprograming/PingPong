using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class scoreManager : NetworkBehaviour
{

    private NetworkVariable<int> paddle1Score = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone);

    private NetworkVariable<int> paddle2Score = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone);

    public TextMeshProUGUI paddle1ScoreText;

    public TextMeshProUGUI paddle2ScoreText;

    public void Paddle1Scored()
    {
        paddle1Score.Value++;
        paddle1ScoreText.text = paddle1Score.Value.ToString();
        
    }


    public void Paddle2Scored()
    {
        paddle2Score.Value++;
        paddle2ScoreText.text = paddle2Score.Value.ToString();
    }
}
