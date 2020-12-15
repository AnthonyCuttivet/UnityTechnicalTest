using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerControls : MonoBehaviour
{
    public GameObject RArmSocket;
    public GameObject LArmSocket;
    public List<GameObject> basicProjectilesPool;
    public int numberOfProjectiles = 2;
    private int projectilePoolIndex = 0;
    private Animator mechAnimator;

    public float fireRate = 0.3f;
    private float timeSinceLastFire = 0.1f;

    private void Start()
    {
        mechAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Animate player
        mechAnimator.SetBool("is_firing", Input.GetButton("Fire1"));
    }
    
    private void ShootProjectile(GameObject armSocket)
    {
        GameObject projectile = basicProjectilesPool[projectilePoolIndex];
        projectile.transform.position = armSocket.transform.position;
        projectile.transform.rotation = armSocket.transform.rotation;
        projectile.SetActive(true);
        if(++projectilePoolIndex >= basicProjectilesPool.Count)
        {
            projectilePoolIndex = 0;
        }
    }

    private void Shoot()
    {
        ShootProjectile(RArmSocket);
        ShootProjectile(LArmSocket); 
        timeSinceLastFire = 0f;
    }


}
