using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour
{
    public List<GameObject> addClicked = new List<GameObject>();
    public delegate void ObjectClicked(GameObject clickedObject);
    public static event ObjectClicked OnObjectClicked;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void OnButtonClick()
    {

    }
        // Update is called once per frame
        void Update()
    {
        // swap_Item_toBoard();
       
    }
    public void select_Item(GameObject item)
    {
        // item = EventSystem.current.currentSelectedGameObject;
        //addClicked.Add(item);
    }
   
    void OnMouseDown()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        
            Debug.Log("Button clicked: " + clickedButton.name);
        
    }

    
    public void swap_Item_toBoard()
    {
        //if (item != null)
        //{
        //item.AddComponent<Button>();

        // item = Instantiate(EventSystem.current.currentSelectedGameObject.gameObject);
        GameObject item = EventSystem.current.currentSelectedGameObject.gameObject;
        addClicked.Add(item);
        
        //print("clicked"+ item.name);
        //item.transform.parent = Initiative_BoardParent;
        print("clicked1");
        //item.transform.parent = Initiative_BoardParent;
        //}
        // selected.transform.localScale = Initiative_BoardParent.transform.localScale;
    }
}
