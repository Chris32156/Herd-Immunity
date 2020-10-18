using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highscore;

    bool buttonPressed = false;

    AudioManagement audio;
    SceneManagement scene;

    // Start is called before the first frame update
    void Start()
    {
        audio = FindObjectOfType<AudioManagement>();
        scene = FindObjectOfType<SceneManagement>();

        highscore.SetText("High Score " + PlayerPrefs.GetInt("High Score", 0).ToString());
    }

    public void NormalButton()
    {
        if (!buttonPressed)
        {
            PlayerPrefs.SetInt("Difficulty", 0);
            audio.ButtonSound();
            scene.LoadScene("Game");
            buttonPressed = true;
        }
    }

    public void HardButton()
    {
        if (!buttonPressed)
        {
            PlayerPrefs.SetInt("Difficulty", 1);
            audio.ButtonSound();
            scene.LoadScene("Game");
            buttonPressed = true;
        }
    }

    public void PlayAgain()
    {
        if (!buttonPressed)
        {
            audio.ButtonSound();
            scene.LoadScene("Game");
            buttonPressed = true;
        }
    }

    public void Menu()
    {
        if (!buttonPressed)
        {
            audio.ButtonSound();
            scene.LoadScene("Main Menu");
            buttonPressed = true;
        }
    }
}
