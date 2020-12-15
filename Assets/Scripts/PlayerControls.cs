using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameObject RArmSocket;
    public GameObject LArmSocket;
    public List<GameObject> projectilesReadyPool;
    private int projectilePoolIndex = 0;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        
    }
}
