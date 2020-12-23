using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelTrigger : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D rb1;
    public Rigidbody2D rb2;
    public Rigidbody2D rb3;

    public float Bforce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            rb.velocity = Vector2.left * Bforce;
            rb1.velocity = Vector2.left * Bforce;
            rb2.velocity = Vector2.left * Bforce;
            rb3.velocity = Vector2.left * Bforce;
        }
    }
}
