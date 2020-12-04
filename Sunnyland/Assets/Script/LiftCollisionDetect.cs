using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftCollisionDetect : MonoBehaviour
{
    public Transform platform;
    private bool isMoving;
    public float liftspeed;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isMoving = true;
        }
        //platform.position = new Vector2(platform.position.x, platform.position.y * liftspeed);
    }
    private void FixedUpdate()
    {
        if (isMoving)
        {
            if (platform.position.y >= 17.59)
            {
                isMoving = false;
            }
            else
            {
                platform.position += new Vector3(0, 1, 0) * Time.deltaTime * liftspeed;
            }            
        }
    }
}
