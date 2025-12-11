using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class mainController : MonoBehaviour
{
    public Initiative_Controller initScript;
   
    

    public float timer;
    public Text timerTxt;
    public bool istimeRunning;

    
    public bool isRoomCreated;
    public Text roomText;
    public GameObject _startBut;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*if (PhotonNetwork.CurrentRoom.PlayerCount == 2) //(PhotonNetwork.InRoom) 
        {
            _startPanel.gameObject.active = true;
            //initScript.stopLoop = false;
            
        }*/
        istimeRunning = false;

         timer = 30f;

        
    }
    void _spawnCards()
    {
        
        if (!initScript.stopLoop)
        {

            initScript.start_Turn();
            print("runn2");
        }
    }

    
    public void CheckBothRoomJoined()
    {
         if (PhotonNetwork.InRoom)
        //if (PhotonNetwork.IsConnected)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2) //(PhotonNetwork.InRoom) 
            {
                print(" COunt " + PhotonNetwork.CurrentRoom.PlayerCount.ToString());
                // isRoomCreated = true;
                if (isRoomCreated)
                {
                    roomText.text = "Room Created";
                    isRoomCreated = false;
                    _startBut.gameObject.active = true;

                }
            }
        }

        else
        {
            roomText.text = "Waiting For Opponent...";
            isRoomCreated = true;
        }

    }
    

    
        // Update is called once per frame
    void Update()
    {

        CheckBothRoomJoined();
        if (istimeRunning)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                //timerTxt.text = timer.ToString();
                timerTxt.text = Mathf.Ceil(timer).ToString();
            }
            else
            {
                initScript.reset();
                timer = 30f;
            }
        }
        
        
            _spawnCards();
    }
    public void playTapaudio(AudioSource aud)
    {
        aud.Play();
    }
    
}
