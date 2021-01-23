using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public LayerMask groundLayer;

    public bool onGround;
    public bool onWall;
    public bool onRightWall;
    public bool onLeftWall;
    public int wallSide;

    public float collisionradius = 0.25f;
    public Vector2 bottomOffset, rightOffset, leftOffset;
}
