using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    public int StartingPeople;

    int people;

    AudioManagement audio;
    SceneManagement scene;
    Game game;

    // Start is called before the first frame update
    void Start()
    {
        audio = FindObjectOfType<AudioManagement>();
        scene = FindObjectOfType<SceneManagement>();
        game = FindObjectOfType<Game>();

        people = StartingPeople;
    }

    public void Died()
    {
        people--;

        if (people <= 0)
        {
            Debug.Log("Game Over");
            GameOver();
        }
    }

    public void GameOver()
    {
        game.SetScores();
        audio.GameOverSound();
        scene.LoadScene("Game Over");
    }
}
