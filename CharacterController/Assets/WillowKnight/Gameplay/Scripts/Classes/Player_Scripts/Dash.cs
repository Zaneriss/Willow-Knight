using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This is a dash mechanic left over from an older version of the build that currently serves no purpose
//its kept here in the event that is gets re implimented further into the prototype

public class Dash : MonoBehaviour {

    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    //public GameObject particleEffect;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;

    }

    // Update is called once per frame
    void Update()
    {

        if (direction == 0)
        {
            if (Input.GetButtonDown("Left Z"))
            {
                //Instantiate(particleEffect, transform.position, Quaternion.identity);
                direction = 1;
            }
            else if (Input.GetButtonDown("Right X"))
            {
                //Instantiate(particleEffect, transform.position, Quaternion.identity);
                direction = 2;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }

            }

            //GameObject clone = (GameObject)Instantiate(particleEffect, transform.position, Quaternion.identity);
        } 
    }
}

