using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreButtonScript : MonoBehaviour
{
    AudioSource audiosource;
    public AudioClip audio1;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCLick()
    {
        SceneManager.LoadScene("HighScoreScene");
        audiosource.PlayOneShot(audio1);
    }
}
