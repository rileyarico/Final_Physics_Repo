using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void DeactivateThis()
    {
        this.gameObject.SetActive(false);
    }

    public void ActivateThis()
    { 
        this.gameObject.SetActive(true); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
