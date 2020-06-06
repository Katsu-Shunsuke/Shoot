using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    //所持金をshop画面に表示
    
    public int scoreUpCost;
    public int scoreUpLevel;

    public Text scoreText;
    public Text scoreUpTextNowText;
    public Text scoreUpButtonText;

    void Start()
    {
        scoreUpLevel = PlayerPrefs.GetInt("ScoreUpLevel");
    }

    
    public void Update()
    {
        //所持金を表示
        scoreText.text = PlayerPrefs.GetInt("Score") + "円";

        //Text系
        scoreUpTextNowText.text = "×" + ((PlayerPrefs.GetInt("ScoreUpLevel") * 0.1f) + 0.9f);
        scoreUpButtonText.text = "LEVEL" + PlayerPrefs.GetInt("ScoreUpLevel") + "\n" + (PlayerPrefs.GetInt("ScoreUpLevel")* 100) + "円";

        
    }

    public void OnClickScoreUp()
    {
        scoreUpCost = PlayerPrefs.GetInt("ScoreUpLevel") * 100;
        if (scoreUpCost < PlayerPrefs.GetInt("Score"))
        {
            scoreUpLevel++;
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - scoreUpCost);
            PlayerPrefs.SetInt("ScoreUpLevel", scoreUpLevel);
        }
    }

    public void BackMain()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void OnClickGameStart()
    {
        SceneManager.LoadScene("GameScene");
        int playnumber = PlayerPrefs.GetInt("Playnumber") + 1;
        PlayerPrefs.SetInt("Playnumber", playnumber);

    }
}
