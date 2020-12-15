using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public static GameManager _instance;

    //Score
    public int score = 0;
    public int killPointsBase = 100;
    public int pointsModifier = 20;
    public TextMeshProUGUI scoreText;
    public GameObject scoreGain;
    
    //Combo
    public int combo = 0;
    public TextMeshProUGUI comboText;
    
    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }
 
        _instance = this;
        DontDestroyOnLoad( this.gameObject );
    }
    
    // Update is called once per frame
    void Update()
    {
        //Score
        scoreText.text = score.ToString();
        //Combo
        comboText.text = combo.ToString();
    }

    public void AddPoints()
    {
        int scoreToAdd = killPointsBase + (Random.Range(-pointsModifier, pointsModifier));
        
        //Add score animation
        scoreGain.GetComponent<TextMeshProUGUI>().text = "+ " + scoreToAdd.ToString();
        scoreGain.SetActive(true);
        score += scoreToAdd;
    }

    public void AddCombo()
    {
        combo++;
    }

    public void ResetCombo()
    {
        combo = 0;
    }
}
