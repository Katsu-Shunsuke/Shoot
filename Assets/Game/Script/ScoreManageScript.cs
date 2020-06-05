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
    public static int score;
    //最初のスコア
    public int firstscore;

    public static float combotimer;
    public static int combo=0;
    public Text combotext;

    public static float score_f;

    
    public Text addScoreText;

    public int levelscoreever;
    public static bool levelbool = true;

    public static bool scorebool = true;
    public int oneplayscore;

    void Start()
    {
        //今の金額
        score = PlayerPrefs.GetInt("Score");
        firstscore = score;
        combo = 0;
        combotimer = 0f;

    }

    void Update()
    {
        //textに入力
        
        scoretext.text = score+ "円";

        GameObject SceneManagemenet = GameObject.Find("SceneManagement");
        if (SceneManagemenet.GetComponent<SceneManageScript>().nowPlaying == false)
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

        

        PlayerPrefs.SetInt("Score", score);

       

        
        combotimer -= Time.deltaTime;
      
        if (combotimer <= 0)
        {
            combotimer = 0f;
            combo = 0;
        }
        combotext.text = "COMBO:" + combo;

        addScoreText.text = "+" + score_f;
    }

    //TargetObjectから
    public static void AddScore()
    {
        
        //スコアを100追加
        score_f = 100* ((PlayerPrefs.GetInt("ScoreUpLevel") * 0.1f) + 0.9f);
        score += (int)score_f;

        Combo();
        
    }

    public static void Combo()
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

   
}
