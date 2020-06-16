using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSpeedScript : MonoBehaviour
{
    //レベル
    public int BallSpeedLevel;

    public Text Nowtext;

    public Text NowLevelText;

    public Text ButtonText;

    public Text CostText;

    public Image Image;
    public Sprite sprite;

    public int levelUpCost;

    // Start is called before the first frame update
    void Start()
    {
        BallSpeedLevel = PlayerPrefs.GetInt("BallSpeedLevel");
    }

    // Update is called once per frame
    void Update()
    {
        ButtonText.text = "LEVEL" + PlayerPrefs.GetInt("BallSpeedLevel");

        if (ScoreUpScript.index == 3)
        {
            
            NowLevelText.text = "LEVEL" + PlayerPrefs.GetInt("BallSpeedLevel");
            CostText.text = PlayerPrefs.GetInt("BallSpeedLevel") * 1000 + "円";
            Image.sprite = sprite;
            Nowtext.text = "ボール発射スピードが" + "\n" + (PlayerPrefs.GetInt("BallSpeedLevel") * 5+15) ;
        }
        else
        {
            Nowtext.text = "";

        }
    }

    public void OnClickForth()
    {
        ScoreUpScript.index = 3;

    }

    public void OnClickBallSpeed()
    {
        if (ScoreUpScript.index == 3)
        {
            levelUpCost = PlayerPrefs.GetInt("BallSpeedLevel") * 1000;
            if (levelUpCost < PlayerPrefs.GetInt("Score"))
            {
                int t = PlayerPrefs.GetInt("BallSpeedLevel") + 1;
                PlayerPrefs.SetInt("BallSpeedLevel", t);
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - levelUpCost);
            }
        }
    }
}
