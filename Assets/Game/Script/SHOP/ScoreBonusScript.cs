using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBonusScript : MonoBehaviour
{
    //レベル
    public int ScoreBonusLevel;

    public Text Nowtext;

    public Text Buttontext;

    public Text NowLevelText;

    public Text ButtonText;

    public int levelUpCost;

    // Start is called before the first frame update
    void Start()
    {
        ScoreBonusLevel = PlayerPrefs.GetInt("ScoreBonusLevel");
    }

    // Update is called once per frame
    void Update()
    {
        //Nowtext.text =(PlayerPrefs.GetInt("ScoreBonusLevel")*0.1f)+"%";
        ButtonText.text = "LEVEL" + PlayerPrefs.GetInt("ScoreBonusLevel");

        if (ScoreUpScript.index == 2)
        {
            Nowtext.text = "ScoreBonus";
            NowLevelText.text = "LEVEL" + PlayerPrefs.GetInt("ScoreBonusLevel");
            Buttontext.text =PlayerPrefs.GetInt("ScoreBonusLevel") * 100 + "円";
            Debug.Log(2);
        }
        else
        {
            Nowtext.text = "";
            
        }
    }


    public void OnClickThird()
    {
        ScoreUpScript.index = 2;
        
    }

    public void OnClickScoreBonus()
    {
        if (ScoreUpScript.index == 2)
        {
            levelUpCost = PlayerPrefs.GetInt("ScoreBonusLevel") * 100;
            if (levelUpCost < PlayerPrefs.GetInt("Score"))
            {
                int t = PlayerPrefs.GetInt("ScoreBonusLevel") + 1;
                PlayerPrefs.SetInt("ScoreBonusLevel", t);
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - levelUpCost);
            }
        }
    }
}
