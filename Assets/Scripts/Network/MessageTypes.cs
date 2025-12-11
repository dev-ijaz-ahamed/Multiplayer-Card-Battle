
using UnityEngine;

[System.Serializable]
public class BaseMessage { public string action; }

[System.Serializable]
public class GameStartMessage : BaseMessage
{
   //string playerIds = PhotonNetwork.LocalPlayer.ActorNumber.ToString();

    public string[] playerIds;
    public int totalTurns;
}

[System.Serializable]
public class SyncBoardMessage : BaseMessage
{
    public int opponentCardCount;
}

[System.Serializable]
public class RevealCardMessage : BaseMessage
{
    public string playerId;
    public int cardId;
    public int orderIndex;
}

[System.Serializable]
public class EndTurnMessage : BaseMessage
{
    public string playerId;
    
}
