using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBonusScript : MonoBehaviour
{
    public int timeBonusLevel;

    // Start is called before the first frame update
    void Start()
    {
        timeBonusLevel = 1;
        PlayerPrefs.SetInt("TimeBonusLevel", timeBonusLevel);
        timeBonusLevel = PlayerPrefs.GetInt("TimeBonusLevel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickTimeBonus()
    {
        int t = PlayerPrefs.GetInt("TimeBonusLevel")+1;
        PlayerPrefs.SetInt("TimeBonusLevel", t);
    }
}
