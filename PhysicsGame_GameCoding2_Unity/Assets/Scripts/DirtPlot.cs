using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DirtPlot : MonoBehaviour
{
    [Header("Grow states in order")]
    public GameObject[] growStates;
    private int growStateIndex = 0;
    private float intervals = 0;

    [Header("UI")]
    public Image growthProgressBar;
    public TextMeshProUGUI displayCrop; 

    private SeedTypes crop;
    private bool isOccupied;
    private float growTime;
    private float timeLeft;
    private GameObject finalGrow;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isOccupied)
        {
            timeLeft -= Time.deltaTime;
            intervals -= Time.deltaTime;
            updateProgressBar();
            if (timeLeft <= 0)
            {
                Debug.Log("Crop is done!");
            }
            if (intervals <= 0)
            {
                manageStates();
                if(growStateIndex <= growStates.Length)
                {
                    manageIntervals();
                }
            }
        }
    }

    private void manageIntervals()
    {
        if(crop.growRate != 0)
        {
            intervals = crop.growRate / (growStates.Length + 1); //adding plus one, because we manually add the last state
        }
        else
        {
            intervals = 15f / (growStates.Length + 1); //adding plus one, because we manually add the last state
        }
    }

    private void updateProgressBar()
    {

    }

    private void manageStates()
    {
        if(growStateIndex < growStates.Length)
        {
            GameObject destroyThis = GetComponentInChildren<GameObject>();
            Destroy(destroyThis);
            Instantiate(growStates[growStateIndex], this.gameObject.transform);
            growStateIndex++;
        }
        else
        {
            GameObject destroyThis = GetComponentInChildren<GameObject>();
            Destroy(destroyThis);
            //instantiate the final cropstate
            Instantiate(crop.grownPrefab, this.gameObject.transform);
        }
        //if there is a next state,  
        //sets timer back if this is not a final state
    }

    private void OnCollisionEnter(Collision collision)
    {
        //returns if space is already occupied
        if(isOccupied == true)
        {
            Debug.Log("Space is already occupied!");
            return;
        }
        //else
        Seed seed = collision.gameObject.GetComponent<Seed>();
        if(seed != null)
        {
            //check if the type is null, otherwise we don't destroy it & instantiate prefab
            if(seed.type == null)
            {
                Debug.Log("Seed type on this object is null");
                return;
            }

            crop = seed.type;
            Debug.Log("Tried to plant " + crop.seedName);

            if (crop.grownPrefab != null)
            {
                //also checks if the grown prefab exists so we can actually instantiate it later.
                Destroy(collision.gameObject);
                //instantiates the first crop state and then increases the index
                Instantiate(growStates[0], this.gameObject.transform);
                growStateIndex = 1;
            }
            else { Debug.Log("Final crop state prefab is null!"); return; }
            if (crop.growRate != 0)
            {
                growTime = crop.growRate;
                timeLeft = crop.growRate;
                manageIntervals();
            }
            else
            {
                growTime = 15f;
                timeLeft = 15f;
                manageIntervals();
            }
        }
    }
}
