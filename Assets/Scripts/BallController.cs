using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    float ballSpeed;
    Rigidbody rb;
    bool gameStarted;
    bool gameOver;


    private void Awake()
    {
       rb=GetComponent<Rigidbody>();
        gameStarted = false;
        gameOver = false;
    }
    // Start is called before the first frame update
    void Start()
    {
       // 
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(ballSpeed, 0, 0);
                gameStarted = true;
            }
            
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.black);


        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            // print("I am tcouching the platform");
            rb.velocity = new Vector3(0, -25f, 0);
            gameOver = true;
        }

        if (Input.GetMouseButtonDown(0)&& !gameOver)
        {
            ChangeBallDirection();
        }
    }

    void ChangeBallDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(ballSpeed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, ballSpeed);
        }
    }
}
