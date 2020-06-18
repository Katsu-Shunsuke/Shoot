using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultLevelScript : MonoBehaviour
{
    public Text level;
    public int Level;
    public int levelscore;

    public int minvalue;
    public int maxvalue;

    public bool Up;
    
    public Slider LevelSlider;

    AudioSource audiosource;
    public AudioClip audio1;

    // Start is called before the first frame update
    void Start()
    {
        level.text = "LEVEL:"+PlayerPrefs.GetInt("Level");
        Level = PlayerPrefs.GetInt("Level");
        Up = false;
        

        if (Level != 0)
        {
            minvalue = (int)Mathf.Pow(2, Level - 1) * 1000;
            maxvalue = (int)Mathf.Pow(2, Level) * 1000;
        }
        if (Level == 0)
        {
            minvalue = 0;
            maxvalue = 1000;
        }

        levelscore = PlayerPrefs.GetInt("LevelScore");
        
        LevelSlider.maxValue = maxvalue - minvalue;
        LevelSlider.value = levelscore - minvalue;

        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        int textlevel = Level + 1;
        level.text = "LEVEL:" + textlevel;

        
        //レベルアップする時
        if (Up)
        {
            LevelSlider.value += (levelscore - minvalue)/100;
            

            if (LevelSlider.value >= LevelSlider.maxValue)
            {
                LevelSlider.value = 0;
                Level++;
                LevelIndex();
                audiosource.PlayOneShot(audio1);
            }
        }

        
        
    }

    public void LevelUpStart()
    {
        levelscore = PlayerPrefs.GetInt("LevelScore");
        LevelIndex();
    }

    public void LevelIndex()
    {
        if (Level != 0)
        { 
            minvalue = (int)Mathf.Pow(2, Level-1) * 1000;
            maxvalue = (int)Mathf.Pow(2, Level) * 1000;
        }
        if (Level == 0)
        {
            minvalue = 0;
            maxvalue = 1000;
        }
        
        if (levelscore >= maxvalue)
        {
            LevelSlider.maxValue = maxvalue - minvalue;
            Up =true;
            
        }
        if (levelscore < maxvalue)
        {
            Up = false;
            LevelSlider.maxValue = maxvalue - minvalue;
            LevelSlider.value = levelscore - minvalue;
            
            //StayLevel();
        }
        
    }

    public void StayLevel()
    {
        
        int deltalevelscore = 0;
        deltalevelscore += (levelscore - minvalue) / 100;
        LevelSlider.value = deltalevelscore / (maxvalue - minvalue);

        while(deltalevelscore < levelscore)
        {
            deltalevelscore += (levelscore - minvalue) / 100;
            LevelSlider.value = deltalevelscore / (maxvalue - minvalue);

            if (deltalevelscore >= levelscore)
            {
                LevelSlider.value = (levelscore - minvalue) / (maxvalue - minvalue);
            }

        }
    }
}
