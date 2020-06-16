using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text score_text;

    public Text highscore_text;

    public int score;
    public int deltascore=0;

    public bool a;

    public GameObject Back;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        
        Back.SetActive(false);
        

        a = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(deltascore);
        
        if (deltascore < score)
        {
            deltascore += score / 100;
            score_text.text = "" + deltascore;
        }
        if (deltascore >= score)
        {
            score_text.text = "" + score;

            Back.SetActive(true);

            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
                highscore_text.text = "HIGHSCORE!!";
            }

             
        }
        
        

        
    }

    public void OnClickNewGame()
    {
        SceneManager.LoadScene("HomeScene");
        PlayerPrefs.SetInt("Score", 100);
        PlayerPrefs.SetInt("Playnumber", 0);
        PlayerPrefs.SetInt("ScoreUpLevel", 1);
        //PlayerPrefs.SetInt("Level", 0);
        //layerPrefs.SetInt("LevelScore", 0);
        PlayerPrefs.SetInt("TimeBonusLevel", 1);
        PlayerPrefs.SetInt("ScoreBonusLevel", 1);
        PlayerPrefs.SetInt("BallSpeedLevel", 1);
    }
}
