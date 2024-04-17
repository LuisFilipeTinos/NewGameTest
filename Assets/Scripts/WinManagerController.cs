using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManagerController : MonoBehaviour
{
    private bool rightPlayerWins;

    public bool GetRightPlayerWins()
    {
        return rightPlayerWins;
    }

    public void SetRightPlayerWins(bool rightWins)
    {
        rightPlayerWins = rightWins;
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
