using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreScript : MonoBehaviour
{
    public Text highscore_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("HighScore") != 0)
        {
            int highscore = PlayerPrefs.GetInt("HighScore");
            highscore_text.text = "" + highscore;
        }
        if (PlayerPrefs.GetInt("HighScore") == 0)
        {
            highscore_text.text = "NoRecord";
        }
    }

    public void ONClick()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
