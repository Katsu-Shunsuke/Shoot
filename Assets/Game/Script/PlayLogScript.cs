using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayLogScript : MonoBehaviour
{
    public Text playlog1;
    public Text playlog2;
    public Text playlog3;
    public Text playlog4;
    public Text playlog5;
    public Text playlog6;
    public Text playlog7;
    public Text playlog8;
    public Text playlog9;
    public Text playlog10;

    public int a;
    public int b;
    public int c;
    public int d;
    public int e;
    public int f;
    public int g;
    public int h;
    public int i;
    public int j;

    public int playnumber;

    // Start is called before the first frame update
    void Start()
    {
        playnumber = PlayerPrefs.GetInt("Playnumber");
    }

    // Update is called once per frame
    void Update()
    {
        if (playnumber == 1)
        {
            PlayerPrefs.SetInt("a" ,PlayerPrefs.GetInt("Score"));
            playlog1.text = "" + PlayerPrefs.GetInt("a");
            playlog2.text = "";
            playlog3.text = "";
            playlog4.text = "";
            playlog5.text = "";
            playlog6.text = "";
            playlog7.text = "";
            playlog8.text = "";
            playlog9.text = "";
            playlog10.text = "";
        }
        if (playnumber == 2)
        {
            PlayerPrefs.SetInt("b", PlayerPrefs.GetInt("Score"));
            playlog1.text = "" + PlayerPrefs.GetInt("a");
            playlog2.text = "" + PlayerPrefs.GetInt("b");
        }
        if (playnumber == 3)
        {
            PlayerPrefs.SetInt("c", PlayerPrefs.GetInt("Score"));
            playlog1.text = "" + PlayerPrefs.GetInt("a");
            playlog2.text = "" + PlayerPrefs.GetInt("b");
            playlog3.text = "" + PlayerPrefs.GetInt("c");
        }
        if (playnumber == 4)
        {
            PlayerPrefs.SetInt("d", PlayerPrefs.GetInt("Score"));
            playlog1.text = "" + PlayerPrefs.GetInt("a");
            playlog2.text = "" + PlayerPrefs.GetInt("b");
            playlog3.text = "" + PlayerPrefs.GetInt("c");
            playlog4.text = "" + PlayerPrefs.GetInt("d");
        }
        if (playnumber == 5)
        {
            PlayerPrefs.SetInt("e", PlayerPrefs.GetInt("Score"));
            playlog1.text = "" + PlayerPrefs.GetInt("a");
            playlog2.text = "" + PlayerPrefs.GetInt("b");
            playlog3.text = "" + PlayerPrefs.GetInt("c");
            playlog4.text = "" + PlayerPrefs.GetInt("d");
            playlog5.text = "" + PlayerPrefs.GetInt("e");
        }
        if (playnumber == 6)
        {
            PlayerPrefs.SetInt("f", PlayerPrefs.GetInt("Score"));
            playlog1.text = "" + PlayerPrefs.GetInt("a");
            playlog2.text = "" + PlayerPrefs.GetInt("b");
            playlog3.text = "" + PlayerPrefs.GetInt("c");
            playlog4.text = "" + PlayerPrefs.GetInt("d");
            playlog5.text = "" + PlayerPrefs.GetInt("e");
            playlog6.text = "" + PlayerPrefs.GetInt("f");
        }
        if (playnumber == 7)
        {
            PlayerPrefs.SetInt("g", PlayerPrefs.GetInt("Score"));
            playlog1.text = "" + PlayerPrefs.GetInt("a");
            playlog2.text = "" + PlayerPrefs.GetInt("b");
            playlog3.text = "" + PlayerPrefs.GetInt("c");
            playlog4.text = "" + PlayerPrefs.GetInt("d");
            playlog5.text = "" + PlayerPrefs.GetInt("e");
            playlog6.text = "" + PlayerPrefs.GetInt("f");
            playlog7.text = "" + PlayerPrefs.GetInt("g");
        }
        if (playnumber == 8)
        {
            PlayerPrefs.SetInt("h", PlayerPrefs.GetInt("Score"));
            playlog1.text = "" + PlayerPrefs.GetInt("a");
            playlog2.text = "" + PlayerPrefs.GetInt("b");
            playlog3.text = "" + PlayerPrefs.GetInt("c");
            playlog4.text = "" + PlayerPrefs.GetInt("d");
            playlog5.text = "" + PlayerPrefs.GetInt("e");
            playlog6.text = "" + PlayerPrefs.GetInt("f");
            playlog7.text = "" + PlayerPrefs.GetInt("g");
            playlog8.text = "" + PlayerPrefs.GetInt("h");
        }
        if (playnumber == 9)
        {
            PlayerPrefs.SetInt("i", PlayerPrefs.GetInt("Score"));
            playlog1.text = "" + PlayerPrefs.GetInt("a");
            playlog2.text = "" + PlayerPrefs.GetInt("b");
            playlog3.text = "" + PlayerPrefs.GetInt("c");
            playlog4.text = "" + PlayerPrefs.GetInt("d");
            playlog5.text = "" + PlayerPrefs.GetInt("e");
            playlog6.text = "" + PlayerPrefs.GetInt("f");
            playlog7.text = "" + PlayerPrefs.GetInt("g");
            playlog8.text = "" + PlayerPrefs.GetInt("h");
            playlog9.text = "" + PlayerPrefs.GetInt("i");
        }
        if (playnumber == 0)
        {
            PlayerPrefs.SetInt("j", PlayerPrefs.GetInt("Score"));
            playlog1.text = "" + PlayerPrefs.GetInt("a");
            playlog2.text = "" + PlayerPrefs.GetInt("b");
            playlog3.text = "" + PlayerPrefs.GetInt("c");
            playlog4.text = "" + PlayerPrefs.GetInt("d");
            playlog5.text = "" + PlayerPrefs.GetInt("e");
            playlog6.text = "" + PlayerPrefs.GetInt("f");
            playlog7.text = "" + PlayerPrefs.GetInt("g");
            playlog8.text = "" + PlayerPrefs.GetInt("h");
            playlog9.text = "" + PlayerPrefs.GetInt("i");
            playlog10.text = "" + PlayerPrefs.GetInt("10thScore");
        }
        
    }
}
