using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ball : MonoBehaviourPunCallbacks, IPunObservable
{
    public Rigidbody rigid;

    private const string PLAYER_TAG = "Player";
    private const string WALL_TAG = "Wall";

    private Vector3 resetPosition;

    private void Awake()
    {
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 60;

        resetPosition = transform.position;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag(PLAYER_TAG))
        {
            photonView.RPC("AddForce", RpcTarget.MasterClient, col.rigidbody.velocity);
        }

    }

    [PunRPC]
    public void AddForce(Vector3 force)
    {
        rigid.velocity = force * 3;
    }

    public void ResetBall()
    {
        transform.position = resetPosition;
        rigid.velocity = Vector3.zero;
    }



    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting && PhotonNetwork.IsMasterClient)
        {
            stream.SendNext(transform.position);
            stream.SendNext(rigid.velocity);
        }
        else
        {
            transform.position = (Vector3)stream.ReceiveNext();
            rigid.velocity = (Vector3)stream.ReceiveNext();
        }
    }


}
