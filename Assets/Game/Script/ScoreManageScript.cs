using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManageScript : MonoBehaviour
{
    //スコアを入れる
    public Text scoretext;
    public int score;
    
    void Start()
    {
        score = 100;
    }

    void Update()
    {
        //textに入力
        scoretext.text = score + "円";

    }
    //TargetObjectから
    public void AddScore()
    {
        //スコアを100追加
        score += 100;
        
    }
    //PlayerMovingScriptから
    public void ballcost()
    {
        score -= 10;
    }
}
