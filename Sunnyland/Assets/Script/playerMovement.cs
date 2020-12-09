using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movement_speed = 5f;
    public float jumpForce = 5f;
    Rigidbody2D rb;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0,0) * Time.deltaTime * movement_speed;
        Vector3 characterflip = transform.localScale;
        if(movement < 0)
        {
            characterflip.x = -6;
        }
        if (movement > 0)
        {
            characterflip.x = 6;
        }
        transform.localScale = characterflip;

        anim.SetFloat("walkingspeed", Mathf.Abs(movement * movement_speed));
        if (Input.GetButtonDown("Jump")&& Mathf.Abs(rb.velocity.y) < 0.000001f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
