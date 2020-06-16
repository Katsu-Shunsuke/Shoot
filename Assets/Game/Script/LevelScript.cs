using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    public Text levelText;
    public int level;

    public Slider LevelSlider;

    public int levelscore;
    public int minvalue;
    public int maxvalue;

    

    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("Level");

        
        if (level != 0)
        {
            minvalue = (int)Mathf.Pow(2, level - 1) * 1000;
            maxvalue = (int)Mathf.Pow(2, level) * 1000;
        }
        if (level == 0)
        {
            minvalue = 0;
            maxvalue = 1000;
        }

        levelscore = PlayerPrefs.GetInt("LevelScore");

        LevelSlider.maxValue = maxvalue - minvalue;
        LevelSlider.value = levelscore - minvalue;
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "LEVEL:" + (PlayerPrefs.GetInt("Level") + 1);

        if (PlayerPrefs.GetInt("LevelScore") >= Mathf.Pow(2, level) * 1000)
        {
            level++;
            PlayerPrefs.SetInt("Level", level);
        }

        if (level != 0)
        {
            minvalue = (int)Mathf.Pow(2, level - 1) * 1000;
            maxvalue = (int)Mathf.Pow(2, level) * 1000;
        }
        if (level == 0)
        {
            minvalue = 0;
            maxvalue = 1000;
        }

        levelscore = PlayerPrefs.GetInt("LevelScore");

        LevelSlider.maxValue = maxvalue - minvalue;
        LevelSlider.value = levelscore - minvalue;

    }

    
}
