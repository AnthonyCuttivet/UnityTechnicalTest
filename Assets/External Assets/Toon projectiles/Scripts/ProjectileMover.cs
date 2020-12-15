using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    public float speed = 15f;
    public float hitOffset = 0f;
    public bool UseFirePointRotation;
    public Vector3 rotationOffset = new Vector3(0, 0, 0);
    public GameObject hit;
    public GameObject flash;
    private Rigidbody rb;
    public GameObject[] Detached;

    private float originalSpeed;
    private float originalHitOffset;
    private GameObject originalHit;
    private GameObject originalFlash;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
        //Pooling var saves
        originalSpeed = speed;
        originalHitOffset = hitOffset;
        if(!originalFlash)
        {
            originalFlash = Instantiate(flash, transform.position, Quaternion.identity);
        }
    }

    private void OnEnable()
    {
        //Set original RB vars
        speed = originalSpeed;
        hitOffset = originalHitOffset;
        rb.constraints = RigidbodyConstraints.None;
        
        //Set original postion
        originalFlash.transform.position = transform.position;
        originalFlash.transform.rotation = Quaternion.identity;
        
        //Activate projectile once it's done
        originalFlash.SetActive(true);
        originalFlash.GetComponentInChildren<ParticleSystem>().Play();
        

    }

    private void Start()
    {
        if (flash != null)
        {
            originalFlash.transform.forward = gameObject.transform.forward;
            var flashPs = originalFlash.GetComponent<ParticleSystem>();
            if (flashPs != null)
            {
                StartCoroutine(DisableParticle(originalFlash,flashPs,flashPs.main.duration));
            }
            else
            {
                var flashPsParts = originalFlash.transform.GetChild(0).GetComponent<ParticleSystem>();
                StartCoroutine(DisableParticle(originalFlash,flashPsParts,flashPsParts.main.duration));
            }
        }
        //Destroy(gameObject,5);
	}

    private void FixedUpdate ()
    {
		if (speed != 0)
        {
            rb.velocity = transform.forward * speed;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
       
        //Lock all axes movement and rotation
        rb.constraints = RigidbodyConstraints.FreezeAll;
        speed = 0;

        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point + contact.normal * hitOffset;

        if (hit != null)
        {
            if(!originalHit)
            {
                originalHit = Instantiate(hit, pos, rot);
            }
            else
            {
                originalHit.transform.position = pos;
                originalHit.transform.rotation = rot;
                
                originalHit.SetActive(true);
                originalHit.GetComponentInChildren<ParticleSystem>().Play();
            }

            if (UseFirePointRotation)
            {
                originalHit.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(0, 180f, 0);
            }
            else if (rotationOffset != Vector3.zero)
            {
                originalHit.transform.rotation = Quaternion.Euler(rotationOffset);
            }
            else
            {
                originalHit.transform.LookAt(contact.point + contact.normal);
            }

            var hitPs = originalHit.GetComponent<ParticleSystem>();
            if (hitPs != null)
            {
                StartCoroutine(DisableParticle(originalHit,hitPs, hitPs.main.duration));
            }
            else
            {
                var hitPsParts = originalHit.transform.GetChild(0).GetComponent<ParticleSystem>();
                StartCoroutine(DisableParticle(originalHit,hitPsParts, hitPsParts.main.duration));
            }
        }
        foreach (var detachedPrefab in Detached)
        {
            if (detachedPrefab != null)
            {
                detachedPrefab.transform.parent = null;
            }
        }
        
        //Deactivate projectile for pooling
        gameObject.SetActive(false);
        //GetComponent<ParticleSystem>().Stop();
        //Destroy(gameObject);
    }

    private IEnumerator DisableParticle(GameObject particle, ParticleSystem particleSystem, float duration)
    {
        yield return new WaitForSeconds(duration);
        particleSystem.Stop();
        particle.SetActive(false);
    }
}