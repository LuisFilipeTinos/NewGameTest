using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Lauch();
    }

    private void Lauch()
    {
        var x = Random.Range(0, 2) == 0 ? -1 : 1;
        var y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb2d.velocity = new Vector2(x * speed, y * speed) * Time.deltaTime;
    }
}
