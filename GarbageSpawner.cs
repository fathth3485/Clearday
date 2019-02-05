using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawner : MonoBehaviour
{
    public GameObject Garbage;
    float maxSpawnRateInSeconds = 3;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnGarbage", maxSpawnRateInSeconds);
        InvokeRepeating("IncreaseSpawnRate", 0, 30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnGarbage()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject aGarbage = (GameObject)Instantiate(Garbage);
        aGarbage.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        SchuduleNexGarbageSpawn();
    }
    void SchuduleNexGarbageSpawn()
     {
            float spawnInSeconds;
            if (maxSpawnRateInSeconds > 1)
            {
                spawnInSeconds = Random.Range(1, maxSpawnRateInSeconds);
            }
            else
                spawnInSeconds = 1;
            Invoke("SpawnGarbage", spawnInSeconds);
      }
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1)
            maxSpawnRateInSeconds--;
        if (maxSpawnRateInSeconds == 1)
            CancelInvoke("IncreaseSpawnRate");
    }

    
}
