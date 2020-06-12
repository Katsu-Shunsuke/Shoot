﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    public int score;
    public float scorebonus;
    public float levelbonus;
    public int total;

    public int deltascore=0;
    public int deltascorebonus = 0;
    public int deltalevelbonus = 0;
    public int deltatotal=0;

    public Text score_text;
    public Text scorebonus_text;
    public Text levelbonus_text;
    public Text total_text;

    public Text playnumber;

    public GameObject Back;

    void Start()
    {
        
        //ボーナスをたす
        scorebonus = (PlayerPrefs.GetInt("Score") - PlayerPrefs.GetInt("FirstScore"))* (PlayerPrefs.GetInt("ScoreBonusLevel") * 0.1f );
        levelbonus = (PlayerPrefs.GetInt("Score") - PlayerPrefs.GetInt("FirstScore"))* (PlayerPrefs.GetInt("Level") * 0.1f );
        float finalscore_f = (PlayerPrefs.GetInt("Score") - PlayerPrefs.GetInt("FirstScore"))+scorebonus + levelbonus;
        
        //ワンプレイスコア
        PlayerPrefs.SetInt("OnePlayScore", (int)finalscore_f);
        int finaltotalscore = PlayerPrefs.GetInt("FirstScore") + (int)finalscore_f;
        PlayerPrefs.SetInt("Score", finaltotalscore);

        int levelscoreever = PlayerPrefs.GetInt("LevelScore") + PlayerPrefs.GetInt("OnePlayScore");
        PlayerPrefs.SetInt("LevelScore", levelscoreever);

        
        score = PlayerPrefs.GetInt("OnePlayScore");
        total= PlayerPrefs.GetInt("Score");

        playnumber.text = "" + PlayerPrefs.GetInt("Playnumber");

        Back.SetActive(false);
    }

    void Update()
    {
        //oneplay
        if(deltascore < score)
        {
            deltascore += score/100;
            score_text.text = "" + deltascore;
        }
        if (deltascore >= score)
        {
            score_text.text = "" + score;

            //scorebonus
            if (deltascorebonus < scorebonus)
            {
                deltascorebonus += (int)(scorebonus / 10);
                score_text.text = "" + deltascorebonus;
            }
            if (deltascorebonus >= scorebonus)
            {
                scorebonus_text .text = "" + (int)scorebonus;

                //levelbonus
                if (deltalevelbonus < levelbonus)
                {
                    deltalevelbonus += (int)(levelbonus / 10);
                    levelbonus_text.text = "" + deltalevelbonus;
                }
                if (deltalevelbonus >= levelbonus)
                {
                    levelbonus_text.text = "" + (int)levelbonus;

                    //total
                    if (deltatotal < total)
                    {
                        deltatotal += total / 100;
                        total_text.text = "" + deltatotal;
                    }
                    if (deltatotal >= total)
                    {
                        total_text.text = "" + total;

                        Back.SetActive(true);
                    }
                }
            }
        }
    }

    
}