using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPlatform : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D rb;
    public GameObject obj;
    public GameObject obj2;
    public SpriteRenderer color;
    Vector3 target;
    public float cooldown = 10;
    public float waitcooldown = 0;

    public float DashForce = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //if (Input.GetKeyDown(skillsummon))
        //{
            //while (flag)
            //{
               // target = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
                
               // color.color = new Color(1, 1, 1, 0.5f);
                //obj2.transform.position = new Vector2(target.x, target.y);
               /* if (Input.GetKeyDown(KeyCode.E))
                {
                    flag = false;
                } */
            //}

            if (Time.time > waitcooldown)
            {
                if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.E))
                {
                    waitcooldown = Time.time + cooldown;
                    target = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
                    // transform.position = new Vector2(target.x, target.y);
                    //color.color = new Color(1, 1, 1, 1);
                    Instantiate(obj, target, Quaternion.identity);
                }

                if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Q))
                {
                    target = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
                    rb.velocity = new Vector3(target.x, target.y, transform.position.z) * DashForce * Time.deltaTime;
                }
            }
        
    }
}
