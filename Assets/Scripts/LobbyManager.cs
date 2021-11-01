using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public GameObject waitingWindow;

    // Start is called before the first frame update
    void Awake()
    {
        Screen.SetResolution(1920, 1080, false);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void TryConnect()
    {
        if (PhotonNetwork.ConnectUsingSettings())
        {
            waitingWindow.SetActive(true);
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = "nickname";
        PhotonNetwork.JoinOrCreateRoom("rkdtks", new RoomOptions { MaxPlayers = 2 }, null);
    }


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        CheckPlayerCount();
    }

    private void CheckPlayerCount()
    {
        if (PhotonNetwork.PlayerList.Length == 2)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

}
