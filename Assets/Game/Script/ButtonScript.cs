using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Text scoretext_Mainscene;

    public Text playnumbertext;
    public static int playnumber;

    public GameObject ScoreManagement;

    //public Text highscore;

    // Start is called before the first frame update
    void Start()
    {
        //playnumbertext.text = "PLAYCOUNT"+"0";
    }

    // Update is called once per frame
    void Update()
    {
        scoretext_Mainscene.text =PlayerPrefs.GetInt("Score")+"円";

        playnumbertext.text = "PLAYCOUNT:"+PlayerPrefs.GetInt("Playnumber");

        //highscore.text = "HIGH SCORE:"+PlayerPrefs.GetInt("OnePlayScore");

    }

    public void OnClickReset()
    {
        PlayerPrefs.SetInt("Score", 100);
        PlayerPrefs.SetInt("Playnumber", 0);
        PlayerPrefs.SetInt("ScoreUpLevel",1);
        PlayerPrefs.SetInt("Level", 0);
        PlayerPrefs.SetInt("LevelScore", 0);
        PlayerPrefs.SetInt("TimeBonusLevel", 1);
        PlayerPrefs.SetInt("ScoreBonusLevel", 1);
        PlayerPrefs.SetInt("BallSpeedLevel", 1);

        ScoreManagement.GetComponent<ScoreManageScript>().score = 100;
        
    }
    public void OnClickShop()
    {
        SceneManager.LoadScene("ShopScene");
    }

    void Playcount()
    {
        
    }
}
