using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{

    private const float TIME_BEFORE_DESTROYED = .5f;
    
    public GameObject playerMech;
    public GameObject explosion;
    public int health = 1;

    private bool wasHit = false;
    private float timeSinceLastHit = 0f;

    private List<Renderer> listRenderer;

    private void Start()
    {
        listRenderer = GetComponentsInChildren<Renderer>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (wasHit)
        {
            timeSinceLastHit += Time.deltaTime;
            if (timeSinceLastHit > TIME_BEFORE_DESTROYED)
            {
                ResetObject();
            }
        }
        else
        {
            GetComponent<NavMeshAgent>().destination = playerMech.transform.position;
        }
        
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerMech.GetComponent<PlayerCharacteristics>().InflictDamage(1);
            PlayDestroyAnimation();
        }
        if (other.gameObject.CompareTag("Projectile"))
        { 
            wasHit = true;
           InflictDamage(playerMech.GetComponent<PlayerCharacteristics>().attack);
           PlayDestroyAnimation();
        }
    }
    
    public void InflictDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            PlayDestroyAnimation();
        }
    }

    private void PlayDestroyAnimation()
    {
        //Hide mesh to play explosion and stop object
        foreach (Renderer r in listRenderer)
        {
            r.enabled = false;
        }
        gameObject.GetComponent<BoxCollider>().enabled = false;
        GameObject explosionToSpawn = Instantiate(explosion, transform);
    }

    private void ResetObject()
    {
        gameObject.SetActive(false);
        foreach (Renderer r in listRenderer)
        {
            r.enabled = true;
        }
        gameObject.GetComponent<BoxCollider>().enabled = true;
        health = 1;
    }
}
