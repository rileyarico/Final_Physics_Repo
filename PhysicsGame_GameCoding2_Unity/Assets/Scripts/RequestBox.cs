using UnityEditor;
using UnityEngine;

public class RequestBox : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string itemName;
    public GameObject itemToCount;
    private int targetCount;
    private GameObject[] boxElements;

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
            requestManager.SetItemTrue(itemName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == itemToCount)
        {
            //add to list
            ArrayUtility.Add<GameObject>(ref boxElements, other.gameObject);
            Debug.Log(boxElements);
            thisCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == itemToCount)
        {
            //remove from list
            ArrayUtility.Remove<GameObject>(ref boxElements, other.gameObject);
            Debug.Log(boxElements);
            thisCount--;
        }
    }
    void RemoveChildren()
    {
        //destroy all items inside this trigger, but only the amount of the request

    }
}
