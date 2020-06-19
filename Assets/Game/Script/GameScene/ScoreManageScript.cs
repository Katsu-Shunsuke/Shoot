using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManageScript : MonoBehaviour
{
    //スコアを入れる
    public Text scoretext;
    
    //スコア
    public int score;
    //最初のスコア
    public int firstscore;

    public float combotimer;
    public int combo=0;
    public Text combotext;

    public float score_f;
    
    public Text addScoreText;

    public int once = 0;

    AudioSource audiosource;
    public AudioClip audio1;

    void Start()
    {
        //今の金額
        score = PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("FirstScore", PlayerPrefs.GetInt("Score"));
        combo = 0;
        combotimer = 0f;

        addScoreText.fontSize = 30;

        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        //textに入力

        scoretext.text = score+ "";
        
        PlayerPrefs.SetInt("Score", score);

        combotimer -= Time.deltaTime;
      
        if (combotimer <= 0)
        {
            combotimer = 0f;
            combo = 0;
        }

        if (combo > 3)
        {
            combotext.text = "COMBO:" + combo;
        }
        else
        {
            combotext.text = "";
        }
        
    }

    //TargetObjectから
    public void AddScoreC()
    {
        
        //スコアを100追加
        score_f = 100* (((PlayerPrefs.GetInt("ScoreUpLevel")+1) * 0.1f) + 0.9f);
        score += (int)score_f;

        Combo();
        AddScoreText();

        audiosource.PlayOneShot(audio1);
    }

    public void AddScoreB()
    {

        //スコアを500追加
        score_f = 500 * (((PlayerPrefs.GetInt("ScoreUpLevel")+1) * 0.1f) + 0.9f);
        score += (int)score_f;

        Combo();
        AddScoreText();

        audiosource.PlayOneShot(audio1);
    }

    public void AddScoreA()
    {

        //スコアを1000追加
        score_f = 1000 * (((PlayerPrefs.GetInt("ScoreUpLevel")+1) * 0.1f) + 0.9f);
        score += (int)score_f;

        Combo();
        AddScoreText();

        audiosource.PlayOneShot(audio1);
    }

    public void AddScoreS()
    {

        //スコアを2000追加
        score_f = 2000 * (((PlayerPrefs.GetInt("ScoreUpLevel")+1) * 0.1f) + 0.9f);
        score += (int)score_f;

        Combo();
        AddScoreText();

        audiosource.PlayOneShot(audio1);
    }

    public void AddScoreSS()
    {

        //スコアを5000追加
        score_f = 5000 * (((PlayerPrefs.GetInt("ScoreUpLevel")+1) * 0.1f) + 0.9f);
        score += (int)score_f;

        Combo();
        AddScoreText();

        audiosource.PlayOneShot(audio1);
    }

    public void Combo()
    {
        
        combotimer = 2.0f;
        
        if (combotimer > 0)
        {
            combo += 1;
            
        }
        if(combotimer <= 0)
        {
            combo = 1;
        }

        if(combo%5==0 & combo != 0)
        {
            SceneManageScript.Combobonus();
        }
    }

    public void AddScoreText()
    {
        addScoreText.text = "+" + score_f;
        addScoreText.fontSize = 70;
        once++;

        Invoke("SmallFont", 3.0f);
        
    }
    void SmallFont()
    {
        
        if (once == 1)
        {
            addScoreText.fontSize = 30;
        }
        if (once != 1)
        {
            once--;
        }
    }

    
}
