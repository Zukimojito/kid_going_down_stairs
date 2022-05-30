using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 8f;
    GameObject currentFloor;
    public float HP = 100f;

    [SerializeField] Text ScoreText;
    int score;
    float scoreTime;

    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreTime = 0f;
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            transform.Translate(-MoveSpeed * Time.deltaTime, 0, 0);
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetBool("Run", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Run", false);
        }
        //Update Score every 2 seconds
        UpdateScore();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("you are on floor");
                currentFloor = other.gameObject;
                HPPlayer(5);
                other.gameObject.GetComponent<AudioSource>().Play();
            }
        }
        else if (other.gameObject.tag == "Fake")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("you are on Fake");
                currentFloor = other.gameObject;
                other.gameObject.GetComponent<AudioSource>().Play();
            }
        }
        else if (other.gameObject.tag == "Nails")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("you are on Nails");
                currentFloor = other.gameObject;
                HPPlayer(-30);
                GetComponent<Animator>().SetTrigger("injury");
                other.gameObject.GetComponent<AudioSource>().Play();
            }
        }
        else if (other.gameObject.tag == "Trampoline")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("you are on Trampoline");
                currentFloor = other.gameObject;
                other.gameObject.GetComponent<AudioSource>().Play();
            }
        }
        else if (other.gameObject.tag == "Conveyor_Left")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("you are on Conveyor_Left");
                currentFloor = other.gameObject;
                other.gameObject.GetComponent<AudioSource>().Play();
            }
        }
        else if (other.gameObject.tag == "Conveyor_Right")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {

                Debug.Log("you are on Conveyor_Right");
                currentFloor = other.gameObject;
                other.gameObject.GetComponent<AudioSource>().Play();
            }
        }
        else if (other.gameObject.tag == "Ceiling")
        {
            Debug.Log("You touch the ceiling");
            currentFloor.GetComponent<BoxCollider2D>().enabled = false;
            HPPlayer(-30);
            other.gameObject.GetComponent<AudioSource>().Play();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DeathLine")
        {
            Debug.Log("you are dead");
            sound.Play();
        }
    }

    void HPPlayer(int num)
    {
        HP += num;
        if (HP > 100)
        {
            HP = 100;
        }
        else if (HP < 0)
        {
            HP = 0;

        }
    }

    void UpdateScore()
    {
        scoreTime += Time.deltaTime;
        if (scoreTime > 2f)
        {
            score += 1;
            scoreTime = 0f;
            ScoreText.text = "Score : " + score.ToString();
        }
    }
}
