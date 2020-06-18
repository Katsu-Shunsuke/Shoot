﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBonusScript : MonoBehaviour
{
    //レベル
    public int ScoreBonusLevel;

    public Text Nowtext;

    

    public Text NowLevelText;

    public Text ButtonText;

    public Text CostText;

    public Image Image;
    public Sprite sprite;

    public int levelUpCost;

    AudioSource audiosource;
    public AudioClip audio1;
    public AudioClip audio2;

    // Start is called before the first frame update
    void Start()
    {
        ScoreBonusLevel = PlayerPrefs.GetInt("ScoreBonusLevel");
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Nowtext.text =(PlayerPrefs.GetInt("ScoreBonusLevel")*0.1f)+"%";
        ButtonText.text = "LEVEL" + PlayerPrefs.GetInt("ScoreBonusLevel");

        if (ScoreUpScript.index == 2)
        {
           
            NowLevelText.text = "LEVEL" + PlayerPrefs.GetInt("ScoreBonusLevel");
            CostText.text =PlayerPrefs.GetInt("ScoreBonusLevel") * 100 + "円";
            Image.sprite = sprite;
            Nowtext.text = "最終スコアに" + "\n" + PlayerPrefs.GetInt("ScoreBonusLevel") * 0.1f + "%加算";
        }
        else
        {
            Nowtext.text = "";
            
        }
    }


    public void OnClickThird()
    {
        ScoreUpScript.index = 2;
        audiosource.PlayOneShot(audio1);
    }

    public void OnClickScoreBonus()
    {
        if (ScoreUpScript.index == 2)
        {
            levelUpCost = PlayerPrefs.GetInt("ScoreBonusLevel") * 100;
            if (levelUpCost < PlayerPrefs.GetInt("Score"))
            {
                int t = PlayerPrefs.GetInt("ScoreBonusLevel") + 1;
                PlayerPrefs.SetInt("ScoreBonusLevel", t);
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - levelUpCost);
                audiosource.PlayOneShot(audio2);
            }
        }
    }
}
