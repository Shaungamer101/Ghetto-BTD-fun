using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonSpawner : MonoBehaviour
{
    public GameObject balloon;
    public float timeBetweenSpawn = 500;
    public float lessFrames;
    public GameObject[] checkpoints;
    private float time = 0;

    // Update is called once per frame
    void Update()
    {
        time--;
        if (time < 0)
        {
            GameObject balloonInstant = Instantiate(balloon);
            balloonInstant.GetComponent<MoveBaloon>().checkPoints = checkpoints;
            timeBetweenSpawn -= lessFrames;
            time = timeBetweenSpawn;
        }
    }
}
