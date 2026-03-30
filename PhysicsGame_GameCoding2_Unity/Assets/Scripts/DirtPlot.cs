using Unity.VisualScripting;
using UnityEngine;

public class DirtPlot : MonoBehaviour
{
    public GameObject[] growStates;
    private int growStateIndex = 0;

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
            
        }
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
                Instantiate(growStates[0], this.gameObject.transform);
            }
            if(crop.growRate != 0)
            {
                growTime = crop.growRate;
                timeLeft = crop.growRate;
            }
            else
            {
                growTime = 15f;
                timeLeft = 15f;
            }
        }
    }
}
