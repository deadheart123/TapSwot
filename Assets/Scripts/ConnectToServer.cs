using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;


public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public TMPro.TMP_InputField nickname;
    void Start()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();        
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void OnConnectedToServer()
    {
        //Establish connection of Player and Photon Server
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connected to the Photon Server");
        PhotonNetwork.NickName = nickname.text;
        Debug.Log("Nickname set to:" + nickname.text);
    }
}
