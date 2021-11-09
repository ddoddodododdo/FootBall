using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ball : MonoBehaviourPunCallbacks, IPunObservable
{
    public Rigidbody rigid;

    private const string playerTag = "Player";
    private const string wallTag = "Wall";


    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag(playerTag))
        {
            photonView.RPC("AddForce", RpcTarget.MasterClient, col.rigidbody.velocity);
        }

    }

    [PunRPC]
    public void AddForce(Vector3 force)
    {
        rigid.velocity = force * 3;
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
