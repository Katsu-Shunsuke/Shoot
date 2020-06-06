using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    public Text levelText;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        level = PlayerPrefs.GetInt("Level");

        if (PlayerPrefs.GetInt("LevelScore") >= Mathf.Pow(2, level) * 1000)
        {
            level++;
            PlayerPrefs.SetInt("Level", level);
        }
        
        levelText.text =( "LEVEL:" + (PlayerPrefs.GetInt("Level")+1));
    }

    
}
