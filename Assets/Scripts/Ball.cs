using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rigid;

    private const string playerTag = "Player";
    private const string wallTag = "Wall";

    void Start()
    {
        
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag(playerTag))
        {
            rigid.velocity = col.rigidbody.velocity * 3;
        }

    }

}
