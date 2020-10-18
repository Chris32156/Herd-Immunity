using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public AudioClip Button;
    public AudioClip Score;
    public AudioClip Died;
    public AudioClip GameOver;

    AudioSource audio;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        var objs = FindObjectsOfType<AudioManagement>();

        if(objs.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    
    public void ButtonSound()
    {
        audio.PlayOneShot(Button);
    }

    public void ScoreSound()
    {
        audio.PlayOneShot(Score);
    }

    public void DiedSound()
    {
        audio.PlayOneShot(Died);
    }

    public void GameOverSound()
    {
        audio.PlayOneShot(GameOver);
    }
}
