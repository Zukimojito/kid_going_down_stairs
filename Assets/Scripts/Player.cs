using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 8f;
    GameObject currentFloor;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            transform.Translate(-MoveSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("you are on floor");
                currentFloor = other.gameObject;
            }
        }
        else if (other.gameObject.tag == "Fake")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("you are on Fake");
                currentFloor = other.gameObject;
            }
        }
        else if (other.gameObject.tag == "Nails")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("you are on Nails");
                currentFloor = other.gameObject;
            }
        }
        else if (other.gameObject.tag == "Trampoline")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("you are on Trampoline");
                currentFloor = other.gameObject;
            }
        }
        else if (other.gameObject.tag == "Conveyor_Left")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("you are on Conveyor_Left");
                currentFloor = other.gameObject;
            }
        }
        else if (other.gameObject.tag == "Conveyor_Right")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {

                Debug.Log("you are on Conveyor_Right");
                currentFloor = other.gameObject;
            }
        }
        else if (other.gameObject.tag == "Ceiling")
        {
            Debug.Log("You touch the ceiling");
            currentFloor.GetComponent<BoxCollider2D>().enabled = false;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DeathLine")
        {
            Debug.Log("you are dead");
        }
    }
}
