using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{
    public float timeAlive = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
        Destroy(gameObject, timeAlive);
    }

    // Update is called once per frame
}
