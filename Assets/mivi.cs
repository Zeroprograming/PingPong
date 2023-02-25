using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mivi : MonoBehaviour
{

    public GameObject ball;
    
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<GameObject>();


    }

    // Update is called once per frame
    void Update()
    {
        movemient();
    }

    public void movemient()
    {
        transform.position += new Vector3(2,1);
    }
}
