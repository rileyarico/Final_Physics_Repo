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

    //Request values
    private int strawbAmt;
    private int cornAmt;
    private int carrotAmt;

    void Start()
    {
        if(strawbText == null || cornText == null || carrotText == null)
        {
            Debug.Log("Request texts not set up in request manager!");
            return;
        }
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
            Debug.Log("Request failed!!!");
        }
        timerText.text = "Timer: " + timer;
    }
    
    void NewRequest()
    {
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
        NewRequest();
    }
}
