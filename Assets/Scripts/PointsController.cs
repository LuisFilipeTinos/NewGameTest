using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI leftPoints;
    [SerializeField] TextMeshProUGUI rightPoints;

    public TextMeshProUGUI GetLeftPoints()
    {
        return leftPoints;
    }

    public TextMeshProUGUI GetRightPoints()
    {
        return rightPoints;
    }

    // Start is called before the first frame update
    void Start()
    {
        leftPoints.text = "0"; 
        rightPoints.text = "0";
    }

    public void ManagePoints(bool isRightPoint)
    {
        if (isRightPoint)
        {
            var points = Convert.ToInt32(rightPoints.text) + 1;
            rightPoints.text = points.ToString(); 
        }
        else
        {
            var points = Convert.ToInt32(leftPoints.text) + 1;
            leftPoints.text = points.ToString();
        }
    }
}
