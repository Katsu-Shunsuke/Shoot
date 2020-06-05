using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Text scoretext_Mainscene;

    public static Text playnumbertext;
    public static int playnumber;

    public Text highscore;

    // Start is called before the first frame update
    void Start()
    {
        playnumbertext.text = "0回";
    }

    // Update is called once per frame
    void Update()
    {
        scoretext_Mainscene.text = PlayerPrefs.GetInt("Score") + "円";

        playnumbertext.text = PlayerPrefs.GetInt("Playnumber")+"回";

        highscore.text = "HIGH SCORE:"+PlayerPrefs.GetInt("OnePlayScore")+"円";

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
        PlayerPrefs.SetInt("OnePlayScore", 0);

        ScoreManageScript.score = 100;
        Debug.Log(ScoreManageScript.score);
    }
    public void OnClickShop()
    {
        SceneManager.LoadScene("ShopScene");
    }

    void Playcount()
    {
        
    }
}
