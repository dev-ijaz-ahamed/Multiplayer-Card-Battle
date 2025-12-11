using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Card_Deck", menuName = "Scriptable Objects/Card_Deck")]
public class Card_Deck : ScriptableObject
{
    public List<Cards_ID_Name> myCard_ID = new List<Cards_ID_Name>();
    //public Material[] _cardMat;
}

/*[System.Serializable]
public class All_Cards
{
    public string card_Name;
    public Image[] cardImage;
}*/
[System.Serializable]
public class Cards_ID_Name
{
    public string card_Name;
    public int[] cardPower;
    public string[] cardPower_Name;
    //public Cards_Power[] cardPow;
    //public int cardPower;
}
