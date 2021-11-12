using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;

public class GameManager : MonoBehaviourPunCallbacks
{
    public Team[] teams;
    public Ball ball;

    private Team myTeam;
    private GameObject myPlayer;


    void Start()
    {
        Team.gameManager = this;
        SetTeamID();
        SetMyTeam();
        MakeMyCharacter();

    }

    private void SetTeamID()
    {
        for(int i = 0; i < teams.Length; i++)
        {
            teams[i].id = i;
        }
    }

    private void SetMyTeam()
    {
        if (PhotonNetwork.IsMasterClient) myTeam = teams[0];
        else myTeam = teams[1]; 
    }

    private void MakeMyCharacter()
    {
        myPlayer = PhotonNetwork.Instantiate("Player", myTeam.spawnPoint.transform.position, Quaternion.identity);
    }

    public void SetPlayerPosReset()
    {
        myPlayer.transform.position = myTeam.spawnPoint.transform.position;
    }

    public void GoalInMessage(int teamID)
    {
        //������ ���� Ŭ�󿡼� �� ������ �޵��� �ǵ������� ȿ���� ��
        if (!PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("GoalIn", RpcTarget.All, teamID);
        }
    }

    [PunRPC]
    public void GoalIn(int teamID)
    {
        teams[teamID].UpScore();
        SetPlayerPosReset();
        //���� ������Ŭ�󿡼� ����ȭ�����ֱ� ����
        if (PhotonNetwork.IsMasterClient)
        {
            ball.ResetBall();
        }
    }

}
