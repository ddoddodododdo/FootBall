using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [HideInInspector]
    public GameObject player;
    public Vector3 followGap;

    private Vector3 targetPos;

    void Start()
    {
        
    }


    void FixedUpdate()
    {
        targetPos = player.transform.position + followGap;
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.05f);
    }

    
}
