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
        scoreUpLevel = 1;
        PlayerPrefs.SetInt("ScoreUpLevel", scoreUpLevel);
        scoreUpLevel = PlayerPrefs.GetInt("ScoreUpLevel");
    }

    
    public void Update()
    {
        //所持金を表示
        scoreText.text = PlayerPrefs.GetInt("Score") + "円";

        //Text系
        scoreUpTextNowText.text = "×" + ((PlayerPrefs.GetInt("ScoreUpLevel") * 0.1f) + 1.0f);
        scoreUpButtonText.text = "LEVEL" + PlayerPrefs.GetInt("ScoreUpLevel") + "\n" + (PlayerPrefs.GetInt("ScoreUpLevel")* 100) + "円";

        //ボタンの色
        if(PlayerPrefs.GetInt("ScoreUpLevel") * 100 > PlayerPrefs.GetInt("Score"))
        {
            var ScoreUp_Button = GameObject.Find("ScoreUp");
            var scoreUp_Button = ScoreUp_Button.GetComponent<Button>();
            var scoreUp_Button_colors = scoreUp_Button.colors;
            scoreUp_Button_colors.normalColor = Color.black;
            Debug.Log("a");
        }
        else
        {
            var ScoreUp_Button = GameObject.Find("ScoreUp");
            var scoreUp_Button = ScoreUp_Button.GetComponent<Button>();
            var scoreUp_Button_colors = scoreUp_Button.colors;
            scoreUp_Button_colors.normalColor = Color.white;
            Debug.Log("b");
        }
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

}
