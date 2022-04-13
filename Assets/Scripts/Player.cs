using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            transform.Translate(-MoveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        }

    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor1")
        {
            Debug.Log("you are on floor1");
        }
        if (other.gameObject.tag == "Floor2")
        {
            Debug.Log("you are on floor2");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathLine")
        {
            Debug.Log("you are dead");
        }
    }
}
