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
    public static int combo;
    
    void Start()
    {
        //今の金額
        score = PlayerPrefs.GetInt("Score");
        firstscore = score;

        combotimer = 0f;
    }

    void Update()
    {
        //textに入力
        scoretext.text = score+ "円";

        GameObject SceneManagemenet = GameObject.Find("SceneManagement");
        if (SceneManagemenet.GetComponent<SceneManageScript>().nowPlaying == false)
        {
            int oneplayscore= score - firstscore;
            finalscore.text = oneplayscore + "円稼ぎました！";

            //highscoreを保存
            if (oneplayscore > PlayerPrefs.GetInt("OnePlayScore"))
            {
                PlayerPrefs.SetFloat("OnePlayScore", oneplayscore);
            }
        }


        PlayerPrefs.SetInt("Score", score);

        if (PlayerPrefs.GetInt("Score") <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
            Cursor.lockState = CursorLockMode.None;
        }

        
        combotimer -= Time.deltaTime;
      
        if (combotimer <= 0)
        {
            combotimer = 0f;
            combo = 0;
        }
        Debug.Log(combotimer);
    }

    //TargetObjectから
    public static void AddScore()
    {
        //スコアを100追加
        float score_f = 100* ((PlayerPrefs.GetInt("ScoreUpLevel") * 0.1f) + 0.9f);
        score += (int)score_f;

        Combo();
    }

    public static void Combo()
    {
        combotimer = 3.0f;

        if (combotimer > 0)
        {
            combo += 1;
            
        }
        if(combotimer <= 0)
        {
            combo = 1;
        }
    }
   
}
