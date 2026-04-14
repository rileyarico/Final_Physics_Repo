using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class RequestBox : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string itemName;
    public GameObject itemToCount;
    private int targetCount;
    private GameObject[] boxElements; //FIX THIS B!!!
    private List<GameObject> boxList = new List<GameObject>();

    private RequestManager requestManager;
    [HideInInspector] public int thisCount;

    void Start()
    {
        //find our request manager
        requestManager = FindFirstObjectByType<RequestManager>();
        if (requestManager != null) 
        {
            Debug.Log("RqManager not found!");
        }
        else
        {
            Debug.Log("RqManager not found!");
        }
    }

    private void Update()
    {
        targetCount = requestManager.GrabRequestAmt(itemName);
        if(thisCount >= targetCount)
        {
            //make value true in RQ Manager
            //requestManager.SetItemTrue(itemName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(itemName)) //if the tag matches itemName
        {
            Debug.Log("Object matches search");
            //add to list
            boxList.Add(other.gameObject);
            //ArrayUtility.Add<GameObject>(ref boxElements, other.gameObject);
            thisCount++;
        }
        Debug.Log("Current List :");
        foreach (GameObject go in boxList)
        {
            Debug.Log(go.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(itemName))
        {
            Debug.Log("Object matches search");
            //remove from list
            boxList.Remove(other.gameObject);
            //ArrayUtility.Remove<GameObject>(ref boxElements, other.gameObject);
            thisCount--;
        }
        Debug.Log("Current List :");
        foreach (GameObject go in boxList)
        {
            Debug.Log(go.name);
        }
    }
    void RemoveChildren()
    {
        //destroy all items inside this trigger, but only the amount of the request

    }
}
