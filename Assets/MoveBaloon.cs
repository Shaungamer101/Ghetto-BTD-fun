using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBaloon : MonoBehaviour

{
    public GameObject self;
    public GameObject[] checkPoints;
    public float speed;
    public float maxError;
    private int currentCPIndex = 0;

    private float seconds = 3f;
    private float frames;

    public Transform prefab;
    public bool willInstantiate = false;

    private float lowerLimit = 0.75f;

    void Update()
    {        
        if (currentCPIndex == -1 || prefab == null) return;

        frames -= Time.deltaTime;

        Debug.Log(1);
        if (frames < 0)
        {
            Debug.Log(2);
            if (willInstantiate)
            {
                Debug.Log(3);
                Instantiate(prefab, new Vector2(-9.98f, 5.26f), Quaternion.identity);
                frames = seconds;

                if (seconds > lowerLimit)
                {
                    seconds = seconds - 0.1f;
                }
            }
        }

        if (!willInstantiate)
        {
            Vector3 displacement = checkPoints[currentCPIndex].transform.position - transform.position;
            Vector3 newDisplacement = new Vector3(0, 0, 0);
            if (displacement.magnitude != 0)
            {
                newDisplacement = (displacement / displacement.magnitude) * speed;
            }
            transform.Translate(newDisplacement);
            if (displacement.magnitude < maxError)
            {
                if (currentCPIndex + 1 < checkPoints.Length)
                {
                    currentCPIndex += 1;
                }
                else
                {
                    currentCPIndex = -1;
                    GameObject.FindObjectOfType<GameManager>().AddBalloon();
                    Destroy(gameObject);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        print("WEQLFIHEWQLIFH");
        if (c.gameObject.tag == "Dart")
        {
            Destroy(gameObject);
        }
    }
}
