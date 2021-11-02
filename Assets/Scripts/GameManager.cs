using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public Team[] teams;

    private Team myTeam;

    void Start()
    {
        SetMyTeam();
        MakeMyCharacter();

    }

    private void SetMyTeam()
    {
        if (PhotonNetwork.IsMasterClient) myTeam = teams[0];
        else myTeam = teams[1]; 
    }

    private void MakeMyCharacter()
    {
        PhotonNetwork.Instantiate("Player", myTeam.spawnPoint.transform.position, Quaternion.identity);
        
    }
   
}
