using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator anim;
    public Transform groundcheck;
    public LayerMask groundLayer;
    public Transform frontcheck;
    public GameObject playerID;

    public float movement_speed = 5f;
    public float jumpForce = 5f;
    public float xwallforce;
    public float ywallforce;
    public float walljumptime;
    public float walljumpLerp = 10;

    private bool isgrounded;
    private bool isTouchingFront;
    private bool wallsliding;
    public float wallslidingSpeed;
    private bool walljumping;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        playerID.transform.position = transform.position;
        
        if (Input.GetMouseButtonDown(1))
        {
            playerID.SetActive(true);
            gameObject.SetActive(false);
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);
        walk(dir);
        //var movement = Input.GetAxisRaw("Horizontal");
        //transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movement_speed;
        Vector3 characterflip = transform.localScale;
        if (dir.x < 0)
        {
            characterflip.x = -6;
        }
        if (dir.x > 0)
        {
            characterflip.x = 6;
        }
        transform.localScale = characterflip;

        anim.SetFloat("walkingspeed", Mathf.Abs(x * movement_speed));

        isgrounded = Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundLayer);
        isTouchingFront = Physics2D.OverlapCircle(frontcheck.position, 0.2f, groundLayer);

        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            jump(Vector2.up);
        }
        if (isTouchingFront && isgrounded == false &&  dir.x != 0)
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
            rb.velocity = new Vector2(xwallforce * -dir.x, ywallforce);
        }


    }
    private void jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;
    }

    void setWallJumpingtofalse()
    {
        walljumping = false;
    }
    private void walk(Vector2 dir)
    {
        rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * movement_speed, rb.velocity.y)), walljumpLerp * Time.deltaTime);
    }
}
