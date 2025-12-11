
using Photon.Pun;
using UnityEngine;
using System.IO;

public static class PhotonSender
{
    public static void Send(object message)
    {
        string json = JsonUtility.ToJson(message);
        PhotonView pv = GameObject.Find("Initiative").GetComponent<PhotonView>();
        pv.RPC("ReceiveJSON", RpcTarget.Others, json);
        Debug.Log(json);
    }

   

}
