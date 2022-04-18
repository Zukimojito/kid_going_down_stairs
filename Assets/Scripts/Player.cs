using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 8f;


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
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        }

    }


    private void OnCollisionEnter(Collision other)
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathLine")
        {
            Debug.Log("you are dead");
        }
    }
}
