using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBonusScript : MonoBehaviour
{
    public int ScoreBonusLevel;

    public Text Buttontext;
    public Text Nowtext;

    public int levelUpCost;

    // Start is called before the first frame update
    void Start()
    {
        ScoreBonusLevel = PlayerPrefs.GetInt("ScoreBonusLevel");
    }

    // Update is called once per frame
    void Update()
    {
        Nowtext.text =(PlayerPrefs.GetInt("ScoreBonusLevel")*0.1f)+"%";
        Buttontext.text = "LEVEL"+PlayerPrefs.GetInt("ScoreBonusLevel")+"\n"+ PlayerPrefs.GetInt("ScoreBonusLevel") * 100 + "円";
    }

    public void OnClickScoreBonus()
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
