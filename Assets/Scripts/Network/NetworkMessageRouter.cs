
using Photon.Pun;
using UnityEngine;

public class NetworkMessageRouter : MonoBehaviourPun
{
    [PunRPC]
    public void ReceiveJSON(string json)
    {
        var baseMsg = JsonUtility.FromJson<BaseMessage>(json);
        Debug.Log("Received action: " + baseMsg.action);

        switch (baseMsg.action)
        {
            case "gameStart":
                var gs = JsonUtility.FromJson<GameStartMessage>(json);
                Debug.Log("Game start received.");
                Debug.Log(gs);
                break;

            case "syncBoard":
                var sb = JsonUtility.FromJson<SyncBoardMessage>(json);
                Debug.Log(sb);
                break;

            case "revealSingleCard":
                var rc = JsonUtility.FromJson<RevealCardMessage>(json);
                Debug.Log(rc);
                break;

            case "endTurn":
                var et = JsonUtility.FromJson<EndTurnMessage>(json);
                Debug.Log(et);
                break;
        }
    }
}
