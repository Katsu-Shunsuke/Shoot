using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpScript : MonoBehaviour
{
    //レベル
    public int scoreUpLevel;
    //説明文
    public Text Nowtext;
    
    

    public Text NowLevelText;

    public Text ButtonText;
    //コスト
    public int scoreUpCost;

    public Text CostText;

    public Image Image;
    public Sprite sprite;

    public static int index=0;

    AudioSource audiosource;
    public AudioClip audio1;
    public AudioClip audio2;

    // Start is called before the first frame update
    void Start()
    {
        scoreUpLevel = (PlayerPrefs.GetInt("ScoreUpLevel")+1);
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Text系
        //NowText.text = "×" + ((PlayerPrefs.GetInt("ScoreUpLevel") * 0.1f) + 0.9f);
        ButtonText.text= "LEVEL" + (PlayerPrefs.GetInt("ScoreUpLevel")+1);

        if (index == 0)
        {
            
            NowLevelText.text = "LEVEL" + (PlayerPrefs.GetInt("ScoreUpLevel")+1);
            CostText.text =((PlayerPrefs.GetInt("ScoreUpLevel")+1) * 100) + "";
            Image.sprite = sprite;
            Nowtext.text = "ヒットした時の得点が" + "\n" + (PlayerPrefs.GetInt("ScoreUpLevel")+1) * 1f + "%アップ";
        }
        else
        {
            Nowtext.text = "";
            
        }
    }

    public void OnClickFirst()
    {
        index = 0;
        audiosource.PlayOneShot(audio1);
    }

    public void OnClickScoreUp()
    {
        
        if (index == 0)
        {
            scoreUpCost = (PlayerPrefs.GetInt("ScoreUpLevel")+1) * 100;
            if (scoreUpCost < PlayerPrefs.GetInt("Score"))
            {
                scoreUpLevel++;
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - scoreUpCost);
                PlayerPrefs.SetInt("ScoreUpLevel", scoreUpLevel);
                audiosource.PlayOneShot(audio2);
            }
        }
    }
}
