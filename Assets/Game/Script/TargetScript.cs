﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour
{
    //的にアタッチするスクリプト
    //的が当たった時の光る部分
    public GameObject collisionchecker;
    MeshRenderer checkermesh;

    // Start is called before the first frame update
    void Start()
    {
        checkermesh = collisionchecker.GetComponent<MeshRenderer>();
        //的の初期設定
        checkermesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (checkermesh.enabled==false)
        {
            GameObject SceneManagement = GameObject.Find("SceneManagement");

            //ゲーム中だったら
            if (SceneManagement.GetComponent<SceneManageScript>().nowPlaying == true)
            {
                //衝突判定ランプ点灯
                checkermesh.enabled=true;

                //１秒後に消える
                Invoke("renewchecker", 1.0f);

                //とりあえずScoreManageScriptのスコアを100加算する関数を起動
                ScoreManageScript.AddScore();
            }
        }
    }
    //衝突判定ランプを消す
    private void renewchecker()
    {
        checkermesh.enabled = false;
    }
}
