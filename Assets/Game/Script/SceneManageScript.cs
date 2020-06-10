using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManageScript : MonoBehaviour
{
    //timerの設定
    public static float timer;
    //時間制限
    public float limittime;
    public Text timetext;

    //timeupの時
    public Text timeuptext;
    //ゲーム中か
    public bool nowPlaying;

    private GameObject ScoreManagement;

    void Start()
    {
        ScoreManagement = GameObject.Find("ScoreManagement");

        //時間制限は
        limittime = 10.0f;
        timer = limittime;

        nowPlaying = true;
    }

    void Update()
    {
        //時間を引いていく
        timer -= Time.deltaTime;
        timetext.text = "TIme:"+timer.ToString("f2");

        //時間がなくなったら止まる
        if (timer <= 0.00f)
        {
            timer = 0.00f;
            timetext.text = "TIme:" + timer.ToString("f2");

            nowPlaying = false;

            

            timeuptext.text="Time Up!!";

            //PlayermovingScriptを参照するため
            GameObject mainCamera=GameObject.Find("Main Camera");

            //Playerを止める
            mainCamera.GetComponent<PlayerMovingScript>().forwardSpeed=new Vector3(0,0,0);

            

            //sceneを５秒後にscoresceneに移動する
            Invoke("Exitgame",5.0f);
        }
    }
    void Exitgame()
    {
        SceneManager.LoadScene("HomeScene");
        Cursor.lockState = CursorLockMode.None;

        ScoreManagement.GetComponent<ScoreManageScript>().levelbool = true;
        ScoreManagement.GetComponent<ScoreManageScript>().scorebool = true;
        

        if (ButtonScript.playnumber == 10)
        {
             SceneManager.LoadScene("GameOverScene");
             Cursor.lockState = CursorLockMode.None;

            PlayerPrefs.SetInt("Score", 100);
            PlayerPrefs.SetInt("Playnumber", 0);
            PlayerPrefs.SetInt("ScoreUpLevel", 1);
            PlayerPrefs.SetInt("TimeBonusLevel", 1);
            PlayerPrefs.SetInt("ScoreBonusLevel", 1);

            ScoreManagement.GetComponent<ScoreManageScript>().score = 100;
        }
    }

    public static void Combobonus()
    {
        timer += PlayerPrefs.GetInt("TimeBonusLevel") * 0.1f;
    }

    
}
