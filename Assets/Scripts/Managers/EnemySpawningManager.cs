using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningManager : MonoBehaviour
{

    public List<GameObject> enemy01List;
    public List<GameObject> enemy02List;
    private int enemy01Index = 0;
    private int enemy02Index = 0;
    public GameObject ground;
    
    //Game vars
    public float spawnRate = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
