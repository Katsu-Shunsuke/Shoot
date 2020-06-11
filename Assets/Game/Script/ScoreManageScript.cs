using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManageScript : MonoBehaviour
{
    //スコアを入れる
    public Text scoretext;
    //最終スコアを入れる
    public Text finalscore;
    //スコア
    public int score;
    //最初のスコア
    public int firstscore;

    public float combotimer;
    public int combo=0;
    public Text combotext;

    public float score_f;
    
    public Text addScoreText;

    public int levelscoreever;
    public bool levelbool = true;

    public bool scorebool = true;
    public int oneplayscore;

    void Start()
    {
        //今の金額
        score = PlayerPrefs.GetInt("Score");
        firstscore = PlayerPrefs.GetInt("Score");
        combo = 0;
        combotimer = 0f;

    }

    void Update()
    {
        //textに入力
        
        scoretext.text = score+ "円";
        Debug.Log(firstscore);
        GameObject SceneManagemenet = GameObject.Find("SceneManagement");
        if (SceneManagemenet.GetComponent<SceneManageScript>().nowPlaying == 0)
        {
            if (scorebool)
            {
                //ボーナスをたす
                float finalscore_f = (score - firstscore) * ((PlayerPrefs.GetInt("Level") + 1) * 0.1f + 1) * (PlayerPrefs.GetInt("ScoreBonusLevel") * 0.1f + 1);
                //ワンプレイスコア
                oneplayscore = (int)finalscore_f;
                finalscore.text = "SCORE:" + oneplayscore;

                score = oneplayscore + firstscore;

                scorebool = false;
            }

            if (levelbool)
            {
                levelscoreever = PlayerPrefs.GetInt("LevelScore") + oneplayscore;
                PlayerPrefs.SetInt("LevelScore", levelscoreever);
                levelbool = false;

            }


            //highscoreを保存
            if (oneplayscore > PlayerPrefs.GetInt("OnePlayScore"))
            {
                PlayerPrefs.SetInt("OnePlayScore", oneplayscore);
            }
        }
        if (SceneManagemenet.GetComponent<SceneManageScript>().nowPlaying != 0)
        {
            finalscore.text = "" ;
        }
        

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
        
        if (addScoreText.GetComponent<Text>().fontSize> 20)
        {
            addScoreText.GetComponent<Text>().fontSize= addScoreText.GetComponent<Text>().fontSize - (addScoreText.GetComponent<Text>().fontSize - 20) / 5;
        }

        
    }

    //TargetObjectから
    public void AddScore()
    {
        
        //スコアを100追加
        score_f = 100* ((PlayerPrefs.GetInt("ScoreUpLevel") * 0.1f) + 0.9f);
        score += (int)score_f;

        Combo();
        AddScoreText();
    }

    public void AddScoreFive()
    {

        //スコアを100追加
        score_f = 500 * ((PlayerPrefs.GetInt("ScoreUpLevel") * 0.1f) + 0.9f);
        score += (int)score_f;

        Combo();
        AddScoreText();
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
        addScoreText.GetComponent<Text>().fontSize = 40;
        
    }
}
