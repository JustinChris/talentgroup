using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowPlayer : MonoBehaviour
{
    public Vector3 offset;
    public Transform playerPosition;
    // Update is called once per frame
    void Update()
    {
        transform.position = playerPosition.position + offset;
    }
}
