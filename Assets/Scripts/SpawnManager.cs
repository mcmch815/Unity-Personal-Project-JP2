using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
public GameObject colltectablePrefab;
public GameObject enemyPrefab;



//Set the spawn ranges
private float spawnRangeX = 20;
private float spawnRangeZ = 20;




    // Start is called before the first frame update
    void Start()
    {
    
        spawnCollectable();
        SpawnEnemyWave();



    }



    // Update is called once per frame
    void Update()
    {
        //spawn a collectable and another enemy after a collectable is collected
        if(GameObject.FindGameObjectsWithTag("Collectable").Length == 0){
           spawnCollectable();
           SpawnEnemyWave();
        
        }

    }

    //generate random spwan position within a range
    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(-spawnRangeZ, spawnRangeZ);
        return new Vector3(xPos, 0.5f, zPos);
    }

    void spawnCollectable(){
       
        // Spawn a collectable at the start of the game
        Instantiate(colltectablePrefab, GenerateSpawnPosition(), colltectablePrefab.transform.rotation);

    }

    void SpawnEnemyWave()
    {

        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

    }

}
