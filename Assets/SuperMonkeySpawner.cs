using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperMonkeySpawner : MonoBehaviour
{
    public GameObject superMonkey;
    public float time;
    private float frames;

    // Update is called once per frame
    void Update()
    {
        frames -= Time.deltaTime;

        if (frames < 0) { 

            //bug.Log(frames);
            if (Input.GetMouseButtonDown(1)) {

                Debug.Log("Instantiate");
                GameObject superMonkeyInstant = Instantiate(superMonkey);
                superMonkeyInstant.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                superMonkeyInstant.transform.position = new Vector3(superMonkeyInstant.transform.position.x, superMonkeyInstant.transform.position.y, 0);
                frames = time;
            }
        }
    }
}
