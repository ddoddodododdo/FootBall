using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        MakeMyCharacter();
    }

    public void MakeMyCharacter()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(0, 1.5f, 0), Quaternion.identity);
    }
   
}
