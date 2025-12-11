using Photon.Pun;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
public class NetworkManager : MonoBehaviourPunCallbacks
{
   
    private const string TestUrl = "http://google.com";
    public Text intrnetText;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
       // StartCoroutine(CheckInternetConnectionCoroutine());
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {

        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
       /* if (PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2 })) //(PhotonNetwork.InRoom) 
        {

            roomText.text = "Waiting For Opponent...";
        }
        else
        {
            isRoomCreated = true;
            if (isRoomCreated)
            {
                roomText.text = "Room Created";
                isRoomCreated = false;
                _startBut.gameObject.active = true;

            }
            

        }*/
    }

    private void Update()
    {
       
    }


    IEnumerator CheckInternetConnectionCoroutine()
    {

        using (UnityWebRequest request = UnityWebRequest.Get(TestUrl))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                intrnetText.text = "Internet Not Connected! Please connect Internet";
                
                Debug.Log("Internet connection error: " + request.error);
            }
            else
            {
                intrnetText.text = " ";
                Debug.Log("Internet connection successful!");
            }
        }
    }
    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("ROOM JOINED - NOW SAFE TO USE RPC");
            Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
           // roomText.text = " " + PhotonNetwork.CurrentRoom.Name.ToString();
        }
        else
        {
            Debug.Log("No one In the Room");

        }
        // EXAMPLE
        // photonView.RPC("TestRPC", RpcTarget.All, "Hello");
    }


}