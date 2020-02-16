using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour
{

    // Variable defined
    public Text moneyText;
    private float moneyCount = 200f;

    private float frames;

    private float seconds = 15.9f;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        frames -= Time.deltaTime;

        if (frames < 0)
        {
            moneyCount += 50;
            moneyText.text = "Money: " + moneyCount;
            frames = seconds;
        }
    }
}
