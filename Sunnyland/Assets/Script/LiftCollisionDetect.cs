using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftCollisionDetect : MonoBehaviour
{
    public Transform platform;
    private bool isMoving;
    public float liftspeed;
    private bool isDashing;
    public Rigidbody2D rb;
    private ParticleSystem particle;
    private SpriteRenderer sr;
    private BoxCollider2D bc;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isMoving = true;
        }
        if (collision.gameObject.tag.Equals("Player") && collision.contacts[0].normal.y > 0.5f && isDashing)
        {
            StartCoroutine(Break());
        }
        //platform.position = new Vector2(platform.position.x, platform.position.y * liftspeed);
    }

    private IEnumerator Break()
    {
        particle.Play();

        sr.enabled = false;
        bc.enabled = false;

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
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
        if (rb.velocity.y > 10f)
        {
            isDashing = true;
        }
        if (rb.velocity.y < 10)
        {
            isDashing = false;
        }
    }
}
