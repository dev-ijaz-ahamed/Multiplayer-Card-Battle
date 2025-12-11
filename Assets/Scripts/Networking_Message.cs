using UnityEngine;

public class Networking_Message : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public Initiative_Controller init_Script;
    public void SendGameStart()
    {
        var msg = new GameStartMessage
        {
            action = "gameStart",
            playerIds = new string[] { "P1", "P2" },
            totalTurns = 6

        };

        PhotonSender.Send(msg);
    }
    public void syncBoard()
    {
        var sync = new SyncBoardMessage
        {
            action = "syncBoard",

            opponentCardCount = 6

        };

        PhotonSender.Send(sync);
    }
}
