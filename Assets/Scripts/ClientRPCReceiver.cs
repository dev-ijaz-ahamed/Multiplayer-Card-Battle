using UnityEngine;
using Photon.Pun;
public class ClientRPCReceiver : MonoBehaviourPunCallbacks
{
    //public Initiative_Controller init_Script;
    [PunRPC]
    public void ReceiveMessageFromMaster(string message)
    {
       // message = init_Script.cardID;
        Debug.Log("Received RPC from Master Client: " + message);
        // Implement client-side logic based on the received message
    }
}
