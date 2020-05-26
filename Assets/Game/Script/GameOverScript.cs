using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNewGame()
    {
        SceneManager.LoadScene("HomeScene");
        PlayerPrefs.SetInt("Score", 100);
        PlayerPrefs.SetInt("Playnumber", 0);
        PlayerPrefs.SetInt("ScoreUplevel", 1);
    }
}
