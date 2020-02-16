using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
   
    private GameObject target;
    public GameObject dart;
    public bool hasPopped = false;
    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Bloon");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(target);
        if (target != null)
        {
            targetBloon(target.transform.position);
            shoot();
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        //records all objects ENTERING the supermonkey's range
        if (col.gameObject.tag == "Bloon")
        {
            //checks if target is a bloon / bad enemy type
            if (!hasPopped) { 
                target = col.gameObject;
            }
            //print(target);
            //targetBloon(target.transform.position);
        }
    }

    float shootingRate = 0.2f; // fire rate
    float shootingTime = 0;
    private void shoot()
    {
        if (shootingTime <= 0)
        {
            shootingTime = shootingRate;
            GameObject make = (GameObject)Instantiate(dart);
            make.transform.rotation = transform.rotation;
            make.transform.position = transform.position;
        }
        shootingTime -= Time.deltaTime;
    }
    private void targetBloon(Vector3 target)
    {
        
        float xPos = target.x - transform.position.x;
        float yPos = target.y - transform.position.y;

        print(xPos);
        print(yPos);
        float angle = Mathf.Atan2(yPos, xPos) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+270));
        print(angle);
    }
}
