using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBonusScript : MonoBehaviour
{
    public int timeBonusLevel;

    public Text Buttontext;
    public Text Nowtext;

    public int levelUpCost;

    // Start is called before the first frame update
    void Start()
    {
        timeBonusLevel = PlayerPrefs.GetInt("TimeBonusLevel");
    }

    // Update is called once per frame
    void Update()
    {
        Nowtext.text = "5combo"+ (PlayerPrefs.GetInt("TimeBonusLevel")*0.1f)+"秒";
        Buttontext.text = "LEVEL"+PlayerPrefs.GetInt("TimeBonusLevel")+"\n"+ PlayerPrefs.GetInt("TimeBonusLevel") * 100 + "円";
    }

    public void OnClickTimeBonus()
    {
        levelUpCost = PlayerPrefs.GetInt("TimeBonusLevel") * 100;
        if (levelUpCost < PlayerPrefs.GetInt("Score"))
        {
            int t = PlayerPrefs.GetInt("TimeBonusLevel") + 1;
            PlayerPrefs.SetInt("TimeBonusLevel", t);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - levelUpCost);
        }
        
    }
}
