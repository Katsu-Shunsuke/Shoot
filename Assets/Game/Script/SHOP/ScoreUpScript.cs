using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpScript : MonoBehaviour
{
    //レベル
    public int scoreUpLevel;
    //説明文
    public Text Nowtext;
    //レベルアップボタンのテキスト
    public Text scoreUpButtonText;

    public Text NowLevelText;

    public Text ButtonText;
    //コスト
    public int scoreUpCost;

    public Text CostText;

    public Image Image;
    public Sprite sprite;

    public static int index=0;

    // Start is called before the first frame update
    void Start()
    {
        scoreUpLevel = PlayerPrefs.GetInt("ScoreUpLevel");
    }

    // Update is called once per frame
    void Update()
    {
        //Text系
        //NowText.text = "×" + ((PlayerPrefs.GetInt("ScoreUpLevel") * 0.1f) + 0.9f);
        ButtonText.text= "LEVEL" + PlayerPrefs.GetInt("ScoreUpLevel");

        if (index == 0)
        {
            Nowtext.text = "ScoreUp";
            NowLevelText.text = "LEVEL" + PlayerPrefs.GetInt("ScoreUpLevel");
            CostText.text =(PlayerPrefs.GetInt("ScoreUpLevel") * 100) + "円";
            Image.sprite = sprite;
            Nowtext.text = "ヒットした時の得点が" + "\n" + PlayerPrefs.GetInt("ScoreUpLevel") * 0.1f + "%アップ";
        }
        else
        {
            Nowtext.text = "";
            
        }
    }

    public void OnClickFirst()
    {
        index = 0;
        
    }

    public void OnClickScoreUp()
    {
        if (index == 0)
        {
            scoreUpCost = PlayerPrefs.GetInt("ScoreUpLevel") * 100;
            if (scoreUpCost < PlayerPrefs.GetInt("Score"))
            {
                scoreUpLevel++;
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - scoreUpCost);
                PlayerPrefs.SetInt("ScoreUpLevel", scoreUpLevel);
            }
        }
    }
}
