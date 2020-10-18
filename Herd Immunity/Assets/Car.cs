using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Sprite[] cars;
    public float MaxY;

    SpriteRenderer sprite;
    Game game;
    AudioManagement audio;

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<Game>();
        sprite = GetComponent<SpriteRenderer>();
        audio = FindObjectOfType<AudioManagement>();

        sprite.sprite = cars[Random.Range(0, cars.Length)];
    }

    private void Update()
    {
        if (transform.position.y <= MaxY)
        {
            game.CarPassed();
            audio.ScoreSound();
            Destroy(gameObject);
        }
    }
}
