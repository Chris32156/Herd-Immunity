using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Game : MonoBehaviour
{
    public GameObject Car;
    public float minTime;
    public float maxTime;
    public float TimeScaleIncrease;
    public TextMeshProUGUI ScoreText;

    float LastTimeSpawned;
    float TimeUntilNextSpawn;
    int NumOfCarsPassed = 0;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();

        if (PlayerPrefs.GetInt("Difficulty") == 1)
        {
            TimeScaleIncrease = TimeScaleIncrease * 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > LastTimeSpawned + TimeUntilNextSpawn)
        {
            Instantiate(Car, new Vector3(Random.Range(-1, 2), 2, 0), transform.rotation);
            ResetTimer();
        }
    }

    void ResetTimer()
    {
        LastTimeSpawned = Time.time;
        TimeUntilNextSpawn = Random.Range(minTime, maxTime);
    }

    public void CarPassed()
    {
        NumOfCarsPassed++;
        ScoreText.SetText(NumOfCarsPassed.ToString());
        Time.timeScale = Time.timeScale + TimeScaleIncrease;
    }

    public void SetScores()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Score", NumOfCarsPassed);
        if (NumOfCarsPassed > PlayerPrefs.GetInt("High Score", 0))
        {
            PlayerPrefs.SetInt("High Score", NumOfCarsPassed);
        }
    }
}
