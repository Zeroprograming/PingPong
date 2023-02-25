/*
 * Date: 25/02/2023
 * Johan Steven Jimenez Avendaño
 * Game control in the menu
 * 
 * Description:
 * 
 * Controls the position of the paddles and the ball, as well as what to do when a point is scored.
 * This script is a singleton instance that can be accessed from any script within the menu.
 */


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private Transform paddle1Transform;    // The transform of the first paddle
    [SerializeField] private Transform paddle2Transform;    // The transform of the second paddle
    [SerializeField] private Transform ballTransform;       // The transform of the ball

    private static MenuManager instance;                    // A static instance of the MenuManager script

    // A getter for the static instance of the MenuManager script
    public static MenuManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MenuManager>();
            }
            return instance;
        }
    }

    // Reset the position of the paddles and the ball to the center of the screen
    public void Restart()
    {
        paddle1Transform.position = new Vector2(paddle1Transform.position.x, 0);
        paddle2Transform.position = new Vector2(paddle2Transform.position.x, 0);
        ballTransform.position = new Vector2(0, 0);
    }
}
