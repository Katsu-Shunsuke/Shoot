using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBonusScript : MonoBehaviour
{
    public int timeBonusLevel;

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
        timeBonusLevel = PlayerPrefs.GetInt("TimeBonusLevel");
    }

    // Update is called once per frame
    void Update()
    {
        //Nowtext.text = "5combo"+ (PlayerPrefs.GetInt("TimeBonusLevel")*0.1f)+"秒";
        ButtonText.text = "LEVEL" + PlayerPrefs.GetInt("TimeBonusLevel");

        if (ScoreUpScript.index == 1)
        {
            
            NowLevelText.text = "LEVEL" + PlayerPrefs.GetInt("TimeBonusLevel");
            CostText.text =PlayerPrefs.GetInt("TimeBonusLevel") * 100 + "円";
            Image.sprite = sprite;
            Nowtext.text = "5コンボで" + "\n" + PlayerPrefs.GetInt("TimeBonusLevel") * 0.1f + "秒追加";
        }
        else
        {
            Nowtext.text = "";
            
        }
    }

    public void OnClickSecond()
    {
        ScoreUpScript.index = 1;
        
    }


    public void OnClickTimeBonus()
    {
        if (ScoreUpScript.index == 1)
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
}
