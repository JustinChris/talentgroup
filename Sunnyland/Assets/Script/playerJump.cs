using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJump : MonoBehaviour
{
    public float smallJumpMultiplier = 2f;
    public float gravityMultiplier = 2.5f;
    Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector2.up * Time.deltaTime * (gravityMultiplier - 1) * Physics2D.gravity.y;
        }
        else if (_rb.velocity.y < 0 && Input.GetButtonDown("Jump"))
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (smallJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
