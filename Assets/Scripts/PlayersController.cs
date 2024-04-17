using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayersController : MonoBehaviour
{
    [SerializeField] bool isPlayerOne;
    [SerializeField] float speed;
    [SerializeField] Transform ball;
    Rigidbody2D rb2d;

    bool isMovingUp;
    bool isMovingDown;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayerOne && Input.GetKey(KeyCode.W))
        {
            isMovingUp = true;
            isMovingDown = false;
        }
        else if (isPlayerOne && Input.GetKey(KeyCode.S))
        {
            isMovingDown = true;
            isMovingUp = false;
        }
        //Caso queira fazer contra a máquina:
        //else if (!isPlayerOne && ball.position.y > transform.position.y)
        //{
        //    isMovingUp = true;
        //    isMovingDown = false;
        //}
        //else if (!isPlayerOne && ball.position.y < transform.position.y)
        //{
        //    isMovingDown = true;
        //    isMovingUp = false;
        //}
        //Caso queira fazer multiplayer:
        else if (!isPlayerOne && Input.GetKey(KeyCode.UpArrow))
        {
            isMovingUp = true;
            isMovingDown = false;
        }
        else if (!isPlayerOne && Input.GetKey(KeyCode.DownArrow))
        {
            isMovingDown = true;
            isMovingUp = false;
        }
        else
        {
            isMovingDown = false;
            isMovingUp = false;
        }
    }

    void FixedUpdate()
    {
        if (isMovingUp)
            rb2d.velocity = new Vector3(0, speed, 0) * Time.deltaTime;
        else if (isMovingDown)
            rb2d.velocity = new Vector3(0, -speed, 0) * Time.deltaTime;
        else
            rb2d.velocity = new Vector3(0, 0, 0);
    }
}
