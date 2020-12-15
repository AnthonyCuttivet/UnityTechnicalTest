using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawningManager : MonoBehaviour
{

    public List<GameObject> enemiesList;
    private int enemyPoolIndex = 0;

    //Game vars
    public float spawnRate = 3f;
    public float spawnX = 120f;
    public float spawnYFixed = 2f;
    public float spawnZ = 120f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnEnemy()
    {
        GameObject enemyToSpawn = enemiesList[enemyPoolIndex];
        enemyToSpawn.transform.position = GetRandomSpawningPoint();
        enemyToSpawn.SetActive(true);
        //Hotfix security
        if(++enemyPoolIndex + 5 >= enemiesList.Count)
        {
            enemyPoolIndex = 0;
        }
    }

    private Vector3 GetRandomSpawningPoint()
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(new Vector3(Random.Range(-spawnX, spawnX), spawnYFixed, Random.Range(-spawnZ, spawnZ)), out hit, 20.0f, NavMesh.AllAreas))
        {
            return hit.position;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
