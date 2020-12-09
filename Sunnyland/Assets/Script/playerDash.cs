using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDash : MonoBehaviour
{
    public float DashSpeed;
    private float DashTime;
    public float startDashTime;
    private int direction;
    private Rigidbody2D _rigid;
    Vector3 target;
    

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        DashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.Q))
            {
                direction = 1;
            }else if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.Q))
            {
                direction = 2;
            }else if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.Q))
            {
                direction = 3;
            }
        }
        else
        {
            if(DashTime <= 0)
            {
                direction = 0;
                DashTime = startDashTime;
                _rigid.velocity = Vector2.zero;
            } else
            {
                DashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    _rigid.velocity = Vector2.left * DashSpeed;
                } 
                else if (direction == 2) {
                    _rigid.velocity = Vector2.right * DashSpeed;
                } 
                else if (direction == 3)
                {
                    _rigid.velocity = Vector2.up * DashSpeed;
                }
            }
        }
    }
}
