using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollapsed : MonoBehaviour
{
    public Rigidbody2D rb;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            rb.isKinematic = false;
            rb.mass = 100f;
        }
    }

}
