using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    public int health = 10;

    public int attack = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InflictDamage(int amount)
    {
        GetComponent<Animator>().SetBool("take_damage", true);
        health -= amount;
        if (health <= 0)
        {
            //Game OVER
        }
    }
}
