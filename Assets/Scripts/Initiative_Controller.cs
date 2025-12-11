using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Photon.Pun;

public class Initiative_Controller : MonoBehaviour
{

    [Space(10)]
    [Header("MonoBehaviour Scripts")]
    public mainController main_script;

    [Space(10)]
    [Header("Scriptable GameObject")]
    public Card_Deck deck_Script;


    [Space(10)]
    [Header("Scroll View Parent For Deck,Initiative and Opponent")]
    public Transform deck_Parent;
    public Transform Initiative_BoardParent;
    public Transform Opponent_BoardParent;
    


    [Space(10)]
    [Header("List Of Cards to Spawn")]
    public List<Current_Cards> myCur_cards = new List<Current_Cards>();
    //public List<Cards_ID_Name> myCard_ID = new List<Cards_ID_Name>();//ijaz


    [Space(10)]
    [Header("List Of Cards to that Spawned into Deck")]
    public List<GameObject> deckInboard = new List<GameObject>();
    [Space(10)]
    [Header("List Of Cards to that Spawned into InitiativeBoard")]
    public List<GameObject> InitiativeInboard = new List<GameObject>();
    [Space(10)]
    [Header("List Of Cards to that Spawned into InitiativeBoard in player point of view")]
    public List<GameObject> MasterRedBoard = new List<GameObject>();
    [Space(10)]
    [Header("List Of Cards to that Spawned into InitiativeBoard in Opponent point of view")]
    public List<GameObject> OpponentRedboard = new List<GameObject>();


    
    public bool stopLoop;
    int prvState;

    [Space(10)]
    [Header("Integers")]
    public int OppavailableCost = 0; 
    public int oppavTotalCost = 1;
    public int myavailableCost = 0;
    public int myavTotalCost = 1;
    public int playerScr;
    public int oppScr;
    public int totalCost = 1;
    public int availableCost = 0;
    // public PhotonView pv;



    [Space(10)]
    [Header("UI Texts")]
    public Text playerScrTxt;
    public Text OppScrText;
    public Text availableTxt;
    public Text OppavailableTxt;
    public Text oppTotalCostTxt;
    public Text totalTxt;
    public Text _playerwinText;
    public Text _oppwinText;
    public Text curTurntxt;
    public Text totalTurntxt;

    public GameObject _endPanel;
    public GameObject playBut;
    void Start()
    {
        // print("sasa"+ myCard_ID[totalRound].cardPower[0].ToString());//75253988-b334-43a6-9886-ae4c508962db
        print("total " + totalRound.ToString());
        //OnClicked();
        
        totalTxt.text = " " + totalCost.ToString();
        curTurntxt.text= " " + EndRound.ToString();


        /* if (!PhotonNetwork.InRoom)
         {
             Debug.LogError("Not in room yet! Cannot send RPC.");
             //stopLoop = false;
             return;
         }*/

    }
    public void SendGameStart()
    {


        main_script.istimeRunning = true;
        stopLoop = false;
        /*var msg = new GameStartMessage
        {

            action = "gameStart",

            playerIds = new string[] { "ID1", "ID2" },
            totalTurns = 6
        };
        PhotonSender.Send(msg);*/

    }
    void OnClicked()
    {
        GameObject item = EventSystem.current.currentSelectedGameObject.gameObject;
        item.transform.parent = Initiative_BoardParent;
    }

    // Update is called once per frame
    

    public void _spawnCards()
    {
        while (!stopLoop)
        {
            start_Turn();
            print("runn2");
        }
    }
    /*public void stateMachine()
    {
        switch (totalRound)
        {
            case One:
                if (!stopLoop)
                {
                    start_Turn();

                }


                break;

            case Two:
                if (!stopLoop)
                {

                   // Round_Two();
                }
                break;


            
        }


    }*/
    
  /*  public void switch_State(int total)
    {
        // _storeState = totalRound;
        if (total == prvState)
        {
            return;
        }

        totalRound = total;
        prvState = total;
        Enter_State();
    }*/

    
    public void get_DeckinBoard(GameObject deck)
    {
        deckInboard.Add(deck);

    }

    public int totalRound = 0;
    public int EndRound=6;
    int startingHand=3;
    //string cardID;
    public void start_Turn()
    {
        // while (deckInboard.Count <= 3)


        //print("runn");
        //stopLoop = false;
        if (deckInboard.Count < startingHand)
        {
          //  print("runn1");
            int random = Random.Range(0, myCur_cards[totalRound].cardImage.Length - 1);
            int RandPower = Random.Range(0, deck_Script.myCard_ID[totalRound].cardPower.Length - 1);

            string RandPower_Name = deck_Script.myCard_ID[totalRound].cardPower_Name[random];//RandPower

            GameObject deck = Instantiate(myCur_cards[totalRound].cardImage[random].gameObject);

            deck.transform.parent = deck_Parent;
            deck.transform.localScale = deck_Parent.transform.localScale;

            deck.transform.GetChild(2).GetComponent<Text>().text = RandPower_Name;
            deck.transform.GetChild(3).GetComponent<Text>().text = deck_Script.myCard_ID[totalRound].cardPower[RandPower].ToString();

            get_DeckinBoard(deck);
        }
        else
        {
            stopLoop = true;
        }





    }
    

    public void select_Item()
    {
        if (availableCost == totalCost)
        {
            //levelUp = true;
            return;
        }

        item = EventSystem.current.currentSelectedGameObject.gameObject;
        playBut.gameObject.active = true;
        // print("fafa" + item.name);
    }




    GameObject item;
     int cardID;
     string cardName;
     int cardPower;
     int opponentCardCount;

    public void swap_Item_toBoard()//swapin Selected card into Initiative Board
    {
        //bool isMine = (playerID == PhotonNetwork.LocalPlayer.ActorNumber);
        //if(item)
        //  myCur_cards[totalRound].cardImage[item]
        availableCost += int.Parse(item.transform.GetChild(1).GetComponent<Text>().text);
        PhotonView pv = PhotonView.Get(this);

        // pv.RPC("RPC_SwapCard", RpcTarget.All, PhotonNetwork.LocalPlayer.ActorNumber, playerID);



        if (availableCost <= totalCost)
        {

            //  print("fafa");
            print("opp");
            GameObject initDeck = Instantiate(item);
            initDeck.transform.parent = Initiative_BoardParent;
            // item = Instantiate(EventSystem.current.currentSelectedGameObject.gameObject);
            cardID = int.Parse(initDeck.transform.GetChild(1).GetComponent<Text>().text);
            cardName = initDeck.transform.GetChild(2).GetComponent<Text>().text;
            cardPower = int.Parse(initDeck.transform.GetChild(3).GetComponent<Text>().text);
            availableTxt.text = availableCost.ToString() ;
            //OppavailableCost=

            //playerScr += cardPower;
            playerScr += cardPower;
            playerScrTxt.text = playerScr.ToString();
            deckInboard.Remove(item);
            Destroy(item);
            InitiativeInboard.Add(initDeck);
            playBut.gameObject.active = false;
            stopLoop = true;

            myavailableCost += availableCost;
            myavailableCost += totalCost;
            //photonView.RPC("ReceiveMessage", RpcTarget.Others, message);
            pv.RPC("RPC_SwapCard", RpcTarget.Others, PhotonNetwork.LocalPlayer.ActorNumber, cardID, cardName, cardPower, availableCost, totalCost);

            //  pv.RPC("RPC_SwapCard", RpcTarget.All, playerScr);
            // RPC_SwapCard(PhotonNetwork.LocalPlayer.ActorNumber, cardID, cardName, cardPower);
            // RevealsingleCard();
            print("ID " + cardID);
            //pv.RPC("RPC_SwapCard", RpcTarget.All, PhotonNetwork.LocalPlayer.ActorNumber, initDeck.transform.GetChild(3).GetComponent<Text>().text);
        }
        else
        {
            availableCost = 0;
        }



    }



    [PunRPC]
    public void RPC_SwapCard(int senderID, int cardID, string cardName, int cardPower, int availableCost, int totalCost)
    {

        GameObject prefabToUse;
        //Text score;
        //Mastertxt.text = "master" + " masterID" + PhotonNetwork.IsMasterClient;
        // If the sender is master → use MasterRedBoard
        if (PhotonNetwork.MasterClient.ActorNumber == senderID)
            prefabToUse = MasterRedBoard[cardID];

        else
            prefabToUse = OpponentRedboard[cardID];



        // Spawn card in opponent's RED ZONE
        GameObject opponent_Deck = Instantiate(prefabToUse);
        //  opponent_Deck.GetComponent<Renderer>().material=deck_Script._cardMat[cardID]
        //   myMaterial[i].GetComponent<Renderer>().material = jersey_Script.materials[(int)jersey_Script.set_IntJersey[IntoppIndex].chooseColour[i].chooseFieldersColour];
        opponent_Deck.transform.SetParent(Opponent_BoardParent, false);

        // Set card data
        opponent_Deck.transform.GetChild(1).GetComponent<Text>().text = cardID.ToString();
        opponent_Deck.transform.GetChild(2).GetComponent<Text>().text = cardName;
        opponent_Deck.transform.GetChild(3).GetComponent<Text>().text = cardPower.ToString();


        oppScr += cardPower;
        OppScrText.text = oppScr.ToString();

        OppavailableCost = availableCost;
        OppavailableTxt.text = OppavailableCost.ToString();

        oppavTotalCost = totalCost;
        oppTotalCostTxt.text = oppavTotalCost.ToString();
        if (totalRound == 5)
        {
            _endPanel.gameObject.active = true;
            if (PhotonNetwork.MasterClient.ActorNumber == senderID)
            {
                if (playerScr > oppScr)
                {
                    _playerwinText.text = "YOU Won";
                }
                else
                {
                    _playerwinText.text = "YOU Lose";
                }
            }
            else
            {
                if (playerScr > oppScr)
                {
                    _playerwinText.text = "YOU Won";
                }
                else
                {
                    _playerwinText.text = "YOU Lose";
                }
            }
        }
        //RevealOpponentCardCount(opponentCardCount);


    }
   
    public void RevealOpponentCardCount(int oppCard)
    {
        var sync = new SyncBoardMessage
        {
            action = "syncBoard",
            opponentCardCount = oppCard
        };
        PhotonSender.Send(sync);
    }

    public void RevealsingleCard()
    {
        var cardMessage = new RevealCardMessage
        {
            action = "revealSingleCard",
            playerId = PhotonNetwork.CurrentRoom.Name,
            cardId = totalCost,
            orderIndex = availableCost

        };
        PhotonSender.Send(cardMessage);
    }

    public void RevealEndTurn()
    {
        var endTurn = new EndTurnMessage
        {
            action = "endTurn",
            playerId = PhotonNetwork.CurrentRoom.Name,


        };
        PhotonSender.Send(endTurn);
    }



    string testString;
    public Text receiveTxt;
    public void TestSendin_rpc()
    {
        testString = "welcome";
        PhotonView pv = PhotonView.Get(this);
        pv.RPC("RPC_SwapCard", RpcTarget.Others, PhotonNetwork.LocalPlayer.ActorNumber, testString);
        //RPC_SwapCard(PhotonNetwork.LocalPlayer.ActorNumber, testString);
    }



    


    /* [PunRPC]
     public void ReceiveMessageFromclient()
     {
         print("in");
         GameObject initDeck = Instantiate(OpponentRedboard[0]);
         initDeck.transform.parent = Opponent_BoardParent;
         initDeck.transform.GetChild(1).GetComponent<Text>().text = cardID;
         //CardID = cardID;
         initDeck.transform.GetChild(2).GetComponent<Text>().text = cardName;
         initDeck.transform.GetChild(3).GetComponent<Text>().text = cardPower;

         print("in");
         // Debug.Log("Received RPC from Master Client: " + message);
         // Implement client-side logic based on the received message
     }

     [PunRPC]
     public void ReceiveMessageFromMaster()
     {
         print("in");
         GameObject initDeck = Instantiate(MasterRedBoard[0]);
         initDeck.transform.parent = Opponent_BoardParent;
         initDeck.transform.GetChild(1).GetComponent<Text>().text = cardID;
         //CardID = cardID;
         initDeck.transform.GetChild(2).GetComponent<Text>().text = cardName;
         initDeck.transform.GetChild(3).GetComponent<Text>().text = cardPower;
         print("in1");

         // Debug.Log("Received RPC from Master Client: " + message);
         // Implement client-side logic based on the received message
     }*/

    public void reset()
    {
        //print("totalRound " + totalRound.ToString());
        //print("availableCost " + availableCost.ToString());
        //print("totalCost " + totalCost.ToString());
        stopLoop = true;
        if (availableCost == totalCost)
        {

            /* for (int i = 0; i < InitiativeInboard.Count; i++)
             {
                 Destroy(InitiativeInboard[i]);
             }


             InitiativeInboard.Clear();*/
            totalRound += 1;
            totalCost += 1;
            availableCost = 0;
            print("run3" + totalCost.ToString());
            totalTxt.text = " " + totalCost.ToString();
            availableTxt.text = " " + availableCost.ToString();
            main_script.timer = 30;
            startingHand = 5;
            //switch_State(totalRound);
            stopLoop = false;



            
            opponentCardCount = totalCost;
            oppavTotalCost = totalRound;
            PhotonView pv = PhotonView.Get(this);
            pv.RPC("RPC_Reset", RpcTarget.Others, opponentCardCount, oppavTotalCost);
            totalTurntxt.text = " " + totalRound;
            // levelUp = false;
        }
        if (totalRound == 6)
        {
            _endPanel.gameObject.active = true;
            if (PhotonNetwork.MasterClient.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
            {
                if (playerScr > oppScr)
                {
                    _playerwinText.text = "YOU Won";
                }
                else
                {
                    _playerwinText.text = "YOU Lose";
                }
            }
            else
            {
                if (playerScr > oppScr)
                {
                    _playerwinText.text = "YOU Won";
                }
                else
                {
                    _playerwinText.text = "YOU Lose";
                }
            }
            /* if (PhotonNetwork.IsMasterClient)
             {
                 PhotonView pv = PhotonView.Get(this);
                 pv.RPC("RPC_GameEnd", RpcTarget.All, playerScr, oppScr);
             }*/
        }
        
    }

    [PunRPC]
    public void RPC_Reset(int senderID,int opponentCardCount, int oppTotalCost)
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == senderID)
        {
            print("RC" + OppavailableTxt.text + "RC1 " + oppTotalCostTxt.text);
            OppavailableCost = opponentCardCount;
            oppavTotalCost = oppTotalCost;

            OppavailableTxt.text = OppavailableCost.ToString();
            oppTotalCostTxt.text = oppavTotalCost.ToString();
        }
        else
        {
            print("RC" + OppavailableTxt.text + "RC1 " + oppTotalCostTxt.text);
            OppavailableCost = opponentCardCount;
            oppavTotalCost = oppTotalCost;

            OppavailableTxt.text = OppavailableCost.ToString();
            oppTotalCostTxt.text = oppavTotalCost.ToString();
        }
    }
}





[System.Serializable]
public class Current_Cards
{
    public string card_Name;
    public GameObject[] cardImage;
}
