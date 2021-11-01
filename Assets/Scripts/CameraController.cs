using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    [HideInInspector]
    public GameObject player;
    public Vector3 followGap;

    private Vector3 targetPos;

    void Awake()
    {
        instance = this;
    }


    void FixedUpdate()
    {
        if (player == null) return;
        targetPos = player.transform.position + followGap;
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.05f);
    }

    
}
