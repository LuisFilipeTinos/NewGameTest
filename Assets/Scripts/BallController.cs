using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float speed;
    PointsController pointsController;
    [SerializeField] WinManagerController winManager;

    // Start is called before the first frame update
    void Start()
    {
        pointsController = GameObject.FindGameObjectWithTag("PointsManager").GetComponent<PointsController>();
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(WaitToStart());
    }

    private IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(1f);
        Launch();
    }

    private void Launch()
    {
        var x = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        var y = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        rb2d.velocity = new Vector2(x * speed, y * speed);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var points = 0;

        if (collision.gameObject.CompareTag("LeftPointMaker"))
        {
            points = Convert.ToInt32(pointsController.GetRightPoints().text);
            ManageBallTriggerAction(points, true);
            
            rb2d.velocity = Vector2.zero;
            this.transform.position = Vector3.zero;
            Launch();

        }
        else if (collision.gameObject.CompareTag("RightPointMaker"))
        {
            points = Convert.ToInt32(pointsController.GetLeftPoints().text);
            ManageBallTriggerAction(points, false);

            rb2d.velocity = Vector2.zero;
            this.transform.position = Vector3.zero;
            Launch();
        }
    }

    public void ManageBallTriggerAction(int points, bool isRightPoints)
    {
        if (points + 1 > 3)
        {
            pointsController.ManagePoints(isRightPoints);

            var rightPoints = Convert.ToInt32(pointsController.GetRightPoints().text);
            var leftPoints = Convert.ToInt32(pointsController.GetLeftPoints().text);

            if (rightPoints > leftPoints)
                winManager.SetRightPlayerWins(true);
            else
                winManager.SetRightPlayerWins(false);

            SceneManager.LoadScene(2);
        }
        else
            pointsController.ManagePoints(isRightPoints);
    }
}
