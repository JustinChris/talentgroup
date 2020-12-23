using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDash : MonoBehaviour
{
    private Rigidbody2D rb;
    

    private float dashTime;
    public float startDashTime;
    private int direction;
    public float dashForce;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var mouseDirection = mousePosition - this.transform.position;
            mouseDirection.z = 0;
            transform.position += mouseDirection;
        } */
        
        if (direction == 0)
        {
            if(Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            {
                direction = 1;
            }else if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            {
                direction = 2;
            }else if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                direction = 3;
            }
        }else
        {
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
            }else
            {
                dashTime -= Time.deltaTime;
                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashForce;
                }else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashForce;
                }else if (direction == 3)
                {
                    rb.velocity = Vector2.up * dashForce;
                }
            }
        }

    }

    private void FixedUpdate()
    {
        
    }
    
   
}
