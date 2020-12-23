using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movement_speed = 5f;
    public float jumpForce = 5f;
    Rigidbody2D rb;
    public Animator anim;
    private bool isgrounded;
    public Transform groundcheck;
    public LayerMask groundlayer;

    bool isTouchingFront;
    public Transform frontcheck;
    bool wallsliding;
    public float wallslidingSpeed;

    bool walljumping;
    public float xwallforce;
    public float ywallforce;
    public float walljumptime;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    private void Update()
    {
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movement_speed;
        Vector3 characterflip = transform.localScale;
        if (movement < 0)
        {
            characterflip.x = -6;
        }
        if (movement > 0)
        {
            characterflip.x = 6;
        }
        transform.localScale = characterflip;

        anim.SetFloat("walkingspeed", Mathf.Abs(movement * movement_speed));

        isgrounded = Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);
        isTouchingFront = Physics2D.OverlapCircle(frontcheck.position, 0.2f, groundlayer);

        if (Input.GetButtonDown("Jump"))
        {
            if (isgrounded)
            {
                jump();
            }
        }
        if (isTouchingFront && isgrounded == false && movement != 0)
        {
            wallsliding = true;
        }else
        {
            wallsliding = false;
        }
        if (wallsliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallslidingSpeed, float.MaxValue));
        }
        if (Input.GetButtonDown("Jump") && wallsliding)
        {
            walljumping = true;
            Invoke("setWallJumpingtofalse", walljumptime);
        }
        if (walljumping)
        {
            rb.velocity = new Vector2(xwallforce * -movement, ywallforce);
        }


    }
    private void jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    void setWallJumpingtofalse()
    {
        walljumping = false;
    }
}
