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

    private float timer = 35f;
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
        if(listOfRequestBoxes == null)
        {
            Debug.Log("Request boxes not given to RqManager!");
        }
        
        NewRequest();
    }

    // Update is called once per frame
    void Update()
    {
        CheckRequestDone();
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
            //Debug.Log("Request failed!!!");
            FailedRequest();
            foreach (RequestBox box in listOfRequestBoxes)
            {
                box.ResetRequestBoxes();
            }
            NewRequest();
        }
        timerText.text = "Timer: " + timer;
    }
    
    void NewRequest()
    {
        timer = 35;
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

    void CheckRequestDone()
    {
        if(strawbDone && cornDone && carrotDone)
        {
            Debug.Log("Request manager says all bools are true! calling RequestDone()");
            RequestDone();
        }
    }

    public void RequestDone()
    {
        //set UI active

        //set bools to false
        strawbDone = false;
        cornDone = false;
        carrotDone = false;
        //destroy items that were given to request
        foreach(RequestBox rq in listOfRequestBoxes)
        {
            rq.DestroyRequested();
            //reset RequestBoxes
            rq.ResetRequestBoxes();
        }

        //message that request fufilled

        Debug.Log("Request fufilled! Starting new request");
        NewRequest(); //resets timer in here
    }

    public void FailedRequest()
    {
        //make fail request UI active for few seconds
        Debug.Log("Request failed! Started new request");
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
