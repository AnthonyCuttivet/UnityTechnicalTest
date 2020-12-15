using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Score
        scoreText.text = score.ToString();
    }

    public void AddPoints()
    {
        int scoreToAdd = killPointsBase + (Random.Range(-pointsModifier, pointsModifier));
        
        //Add score animation
        scoreGain.GetComponent<TextMeshProUGUI>().text = "+ " + scoreToAdd.ToString();
        scoreGain.SetActive(true);
        score += scoreToAdd;
    }
}
