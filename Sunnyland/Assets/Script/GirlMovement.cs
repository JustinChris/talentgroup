using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlMovement : MonoBehaviour
{
    public GameObject girl;
    public float GirlMSpeed = 8f;
    public BoxCollider2D max;
    private bool toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle)
        {
            girl.transform.position += new Vector3(1,0,0) * GirlMSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            //GirlTransform.position += new Vector3(GirlMSpeed, 0,0) * Time.deltaTime;
            toggle = true;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        toggle = false;
    }
}
