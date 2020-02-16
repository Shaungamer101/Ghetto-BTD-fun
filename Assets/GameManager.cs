using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxBalloons;
    public int balloonsCounted;

   public void AddBalloon()
    {
        balloonsCounted++;
        if (balloonsCounted >= maxBalloons)
        {
            Debug.Log("GameOver");
        }
    }
}
