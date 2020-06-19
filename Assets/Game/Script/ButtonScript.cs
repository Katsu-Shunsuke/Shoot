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

    AudioSource audiosource;
    public AudioClip audio1;

    //public Text highscore;

    // Start is called before the first frame update
    void Start()
    {
        //playnumbertext.text = "PLAYCOUNT"+"0";
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        scoretext_Mainscene.text =PlayerPrefs.GetInt("Score")+"";

        playnumbertext.text = "PLAYCOUNT:"+PlayerPrefs.GetInt("Playnumber");

        //highscore.text = "HIGH SCORE:"+PlayerPrefs.GetInt("OnePlayScore");

    }

    public void OnClickReset()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Playnumber", 0);
        PlayerPrefs.SetInt("ScoreUpLevel",0);
        PlayerPrefs.SetInt("Level", 0);
        PlayerPrefs.SetInt("LevelScore", 0);
        PlayerPrefs.SetInt("TimeBonusLevel", 0);
        PlayerPrefs.SetInt("ScoreBonusLevel", 0);
        PlayerPrefs.SetInt("BallSpeedLevel", 1);

        PlayerPrefs.SetInt("a", 0);
        PlayerPrefs.SetInt("b", 0);
        PlayerPrefs.SetInt("c", 0);
        PlayerPrefs.SetInt("d", 0);
        PlayerPrefs.SetInt("e", 0);
        PlayerPrefs.SetInt("f", 0);
        PlayerPrefs.SetInt("g", 0);
        PlayerPrefs.SetInt("h", 0);
        PlayerPrefs.SetInt("i", 0);
        PlayerPrefs.SetInt("10thScore", 0);

        ScoreManagement.GetComponent<ScoreManageScript>().score = 100;
        
    }
    public void OnClickShop()
    {
        SceneManager.LoadScene("ShopScene");
        audiosource.PlayOneShot(audio1);
    }

    void Playcount()
    {
        
    }
}
