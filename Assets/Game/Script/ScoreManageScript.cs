using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    
    void Start()
    {
        //今の金額
        score = PlayerPrefs.GetInt("Score");
        firstscore = score;
    }

    void Update()
    {
        //textに入力
        scoretext.text = score + "円";

        GameObject SceneManagemenet = GameObject.Find("SceneManagement");
        if (SceneManagemenet.GetComponent<SceneManageScript>().nowPlaying == false)
        {
            int oneplayscore= score - firstscore;
            finalscore.text = oneplayscore + "円稼ぎました！";

            PlayerPrefs.SetInt("Score", score);

            //highscoreを保存
            if (oneplayscore > PlayerPrefs.GetInt("OnePlayScore"))
            {
                PlayerPrefs.SetInt("OnePlayScore", oneplayscore);
            }
        }

    }

    //TargetObjectから
    public static void AddScore()
    {
        //スコアを100追加
        score += 100;
        
    }

    //PlayerMovingScriptから
    public static void ballcost()
    {
        score -= 10;
    }
}
