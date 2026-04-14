using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class RequestManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI strawbText;
    public TextMeshProUGUI cornText;
    public TextMeshProUGUI carrotText;
    public TextMeshProUGUI timerText;

    private float timer = 20f;
    private bool strawbDone = false;
    private bool cornDone = false;
    private bool carrotDone = false;

    public RequestBox[] listOfRequestBoxes;

    //Request values
    [HideInInspector] public int strawbAmt;
    [HideInInspector] public int cornAmt;
    [HideInInspector] public int carrotAmt;

    void Start()
    {
        if(strawbText == null || cornText == null || carrotText == null)
        {
            Debug.Log("Request texts not set up in request manager!");
            return;
        }
        //grab all RequestBoxes in scene to destroy their children
        //could also have them set up in inspector, kind of tedious tho

        
        NewRequest();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            //Debug.Log("Request failed!!!");
        }
        timerText.text = "Timer: " + timer;
    }
    
    void NewRequest()
    {
        timer = 20f;
        strawbAmt = Random.Range(0, 3);
        cornAmt = Random.Range(0, 2);
        carrotAmt = Random.Range(0, 2);

        int cummiliative = strawbAmt + cornAmt + carrotAmt;
        if (cummiliative > 7)
        {
            NewRequest();
        }
        else
        {
            strawbText.text = strawbAmt.ToString() + "X";
            cornText.text = cornAmt.ToString() + "X";
            carrotText.text = carrotAmt.ToString() + "X";
        }
    }

    public void RequestDone()
    {
        strawbDone = false;
        cornDone = false;
        carrotDone = false;
        //destroy items that were given to request
        
        //message that request fufilled
        NewRequest(); //resets timer in here
    }

    public int GrabRequestAmt(String req)
    {
        if(req == "Strawberry")
        {
            return strawbAmt;
        }
        if (req == "Corn")
        {
            return cornAmt;
        }
        if (req == "Carrot")
        {
            return carrotAmt;
        }
        Debug.Log("Couldn't find req amount. String likely mispelled!");
        return 0;
    }

    public void SetItemTrue(String item)
    {
        if(item == "Strawberry")
        {
            Debug.Log("Strawb complete!");
            strawbDone = true;
        }
        if (item == "Corn")
        {
            Debug.Log("Corn complete!");
            cornDone = true;
        }
        if (item == "Carrot")
        {
            Debug.Log("Carrot complete!");
            carrotDone = true;
        }
        Debug.Log("Couldn't find bool. String likely mispelled!");
    }
}
