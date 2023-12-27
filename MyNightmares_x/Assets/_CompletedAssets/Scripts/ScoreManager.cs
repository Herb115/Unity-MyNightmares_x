﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static int level;
    public static bool levelup;

    Text text;
    void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
        level=1;
    }

  



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "level:"+level+"    Score: " + score;
        if(score>=level*100){
            level+=1;
            levelup=true;
        }

    }
}
