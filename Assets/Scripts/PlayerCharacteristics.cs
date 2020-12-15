using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    public int health = 10;
    public int attack = 1;
    
    //Health
    public List<Color> healthColors;
    public GameObject healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 7)
        {
            healthBar.GetComponent<SpriteRenderer>().color = healthColors[0];
        }
        else if (health < 7 && health > 3)
        {
            healthBar.GetComponent<SpriteRenderer>().color = healthColors[1];
        }
        else if(health < 3)
        {
            healthBar.GetComponent<SpriteRenderer>().color = healthColors[2];
        }
    }

    public void InflictDamage(int amount)
    {
        GetComponent<Animator>().SetBool("take_damage", true);
        health -= amount;
        if (health <= 0)
        {
            GameManager._instance.GameOver();
        }
    }
}
