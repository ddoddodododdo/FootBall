using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPunCallbacks
{
    public Rigidbody rigid;
    public Animator animator;
    public CameraController cameraController;
    
    private Vector3 moveDir;

    private int aniHashMoveSpeed;

    private float applySpeed;
    private float inputX;
    private float inputZ;
    private float moveBlendValue;

    private const float WALK_SPEED = 3;
    private const float RUN_SPEED = 5;
    //private const float speedLimit = 0.05f;

    private void Awake()
    {
        SetAniHash();
    }

    private void Start()
    {
        if (photonView.IsMine)
            CameraController.instance.player = gameObject;
    }

    private void FixedUpdate()
    {
        MoveControl();
    }

    private void SetAniHash()
    {
        aniHashMoveSpeed = Animator.StringToHash("MoveSpeed");
    }

    private void MoveControl()
    {
        if (PhotonNetwork.IsConnected && !photonView.IsMine) return;

        if (Input.GetKey(KeyCode.LeftShift)) applySpeed = RUN_SPEED;
        else                                 applySpeed = WALK_SPEED;

        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(-inputZ, 0, inputX).normalized * applySpeed;
        rigid.velocity = moveDir;
        //rigid.MovePosition(transform.position + moveDir);

        float moveBlendTarget = 0;
        if (moveDir != Vector3.zero)
        {
            moveBlendTarget = applySpeed;
            //회전
            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.LookRotation(moveDir), 0.2f);
        }
        else
        {
            moveBlendTarget = 0;
        }

        //애니메이션 관련
        
        moveBlendValue = Mathf.Lerp(moveBlendValue, moveBlendTarget, 0.05f);
        animator.SetFloat(aniHashMoveSpeed, moveBlendValue);
    }

}
