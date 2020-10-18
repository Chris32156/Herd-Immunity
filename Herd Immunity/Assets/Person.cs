using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public Sprite[] peopleSprites;

    float minX;
    float maxX;

    People people;
    SpriteRenderer sprite;
    AudioManagement audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = FindObjectOfType<AudioManagement>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = peopleSprites[Random.Range(0, peopleSprites.Length)];
        people = FindObjectOfType<People>();

        minX = transform.position.x - 1;
        maxX = transform.position.x + 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + 1, minX, maxX), transform.position.y, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - 1, minX, maxX), transform.position.y, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            audio.DiedSound();
            people.Died();
            Destroy(gameObject);
        }
    }
}
