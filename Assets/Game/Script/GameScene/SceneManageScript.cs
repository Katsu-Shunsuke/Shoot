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
    public int nowPlaying;

    private GameObject ScoreManagement;

    AudioSource audiosource;
    public AudioClip audio1;

    void Start()
    {
        ScoreManagement = GameObject.Find("ScoreManagement");

        //時間制限は
        limittime = 15.0f;
        timer = limittime;

        nowPlaying = 0;

        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //時間を引いていく
        timer -= Time.deltaTime;
        timetext.text = "TIme:"+timer.ToString("f2");
        if (timer > 14.0f )
        {
            timetext.text = "";
            nowPlaying = 2;
        }
        if (timer > 13.0f & timer<=14.0f)
        {
            timetext.text = "3";
        }
        if (timer > 12.0f & timer <= 13.0f)
        {
            timetext.text = "2";
        }
        if (timer > 11.0f & timer <= 12.0f)
        {
            timetext.text = "1";
        }
        if (timer > 10.0f & timer <= 11.0f)
        {
            timetext.text = "START!";
        }
        if (timer > 0.0f & timer <= 10.0f)
        {
            nowPlaying = 1;
        }
        //時間がなくなったら止まる
        if (timer <= 0.00f)
        {
            timer = 0.00f;
            timetext.text = "TIme:" + timer.ToString("f2");

            audiosource.PlayOneShot(audio1);

            nowPlaying = 0;

            timeuptext.text="Time Up!!";

            //PlayermovingScriptを参照するため
            GameObject mainCamera=GameObject.Find("Main Camera");

            //Playerを止める
            mainCamera.GetComponent<PlayerMovingScript>().forwardSpeed=new Vector3(0,0,0);

            //sceneを3秒後にscoresceneに移動する
            Invoke("Exitgame", 3.0f);
        }
    }
    void Exitgame()
    {
        SceneManager.LoadScene("ResultScene");
        Cursor.lockState = CursorLockMode.None;

        if (PlayerPrefs.GetInt("Playnumber") >= 10)
        {
             SceneManager.LoadScene("GameOverScene");
             Cursor.lockState = CursorLockMode.None;

        }
    }

    public static void Combobonus()
    {
        timer += PlayerPrefs.GetInt("TimeBonusLevel") * 0.1f;
    }

    
}
