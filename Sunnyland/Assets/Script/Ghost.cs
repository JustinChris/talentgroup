using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Girl"))
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<CircleCollider2D>().isTrigger = true;
            Debug.Log("In");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Out");
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<CircleCollider2D>().isTrigger = false;
    }
    
}
