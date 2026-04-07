using System.Collections;
using UnityEngine;

public class SeedManager : MonoBehaviour
{
    public GameObject seedPrefab;
    public int amountToSpawn = 3;
    private int seedCount;

    private void Update()
    {
        GameObject[] hello = GameObject.FindGameObjectsWithTag(seedPrefab.tag);
        seedCount = hello.Length;
        if(seedCount <= 0)
        {
            StartCoroutine(Spawn());
        }
    }

    /*private void SpawnMoreSeeds()
    {
        for(int i = 0; i < amountToSpawn; i++)
        {
            Instantiate(seedPrefab, this.gameObject.transform);
            
        }
        Debug.Log("Spawned new " + seedPrefab.name);
    }*/

    IEnumerator Spawn()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            Instantiate(gameObject, transform);
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("Spawned new " + seedPrefab.name);
    }
}
