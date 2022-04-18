using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float SpeedY = 2f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0, SpeedY * Time.deltaTime, 0);

        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
            transform.parent.GetComponent<FloorManager>().spawnFloor();
        }
    }

    void FixedUpdate()
    {
        transform.Translate(0, SpeedY * Time.deltaTime, 0);
    }
}
