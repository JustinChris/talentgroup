using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPlatform : MonoBehaviour
{
    public Camera cam;
    public GameObject obj;
    public GameObject lessopacityobj;
    public SpriteRenderer toggle;

    Vector3 target;
    public float cooldown = 10;
    public float waitcooldown = 0;
    bool isPressedDown = false;

    private void Start()
    {
        toggle.enabled = false;
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
        
        target = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        
        if (isPressedDown)
        {
            lessopacityobj.transform.position = new Vector2(target.x, target.y);
            
            //summoning();
        }
        if (Input.GetKeyDown(KeyCode.Escape)  && isPressedDown)
        {
            isPressedDown = false;
            toggle.enabled = false;
        }
        if (Time.time > waitcooldown)
        {
            if (Input.GetMouseButtonDown(0) && isPressedDown)
            {
                isPressedDown = false;
                toggle.enabled = false;
                Instantiate(obj, target, Quaternion.identity);
                waitcooldown = Time.time + cooldown;
            }
            /* if (Input.GetKeyDown(KeyCode.E))
             {
                 isPressedDown = true;
                 Instantiate(lessopacityobj, target, Quaternion.identity);

                 if (Input.GetMouseButtonDown(0))
                 {
                     Instantiate(obj, target, Quaternion.identity);
                     waitcooldown = Time.time + cooldown;
                 }


                 while (isPressedDown)
                 {
                     summoning();
                 } */



            // transform.position = new Vector2(target.x, target.y);
            //color.color = new Color(1, 1, 1, 1);



            /* if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Q))
             {
                 target = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
                 rb.velocity = new Vector3(target.x, target.y, transform.position.z) * DashForce * Time.deltaTime;
             } */
        }

    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            toggle.enabled = true;
            isPressedDown = true;
            /*
            if (Input.GetMouseButtonDown(0) && isPressedDown )
            {
                toggle.enabled = false;
                Instantiate(obj, target, Quaternion.identity);
                waitcooldown = Time.time + cooldown;
            }
            */
        }
        
        
    }
    
}


