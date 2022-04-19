using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] GameObject[] FloorPrefabs;
    int floor_start = 6;


    void Awake()
    {
        StartSpawnFloor();
    }

    void Update()
    {

    }

    public void spawnFloor()
    {
        int R = Random.Range(0, FloorPrefabs.Length);
        GameObject floor = Instantiate(FloorPrefabs[R], transform);
        floor.transform.position = new Vector3(Random.Range(-3f, 3.9f), -6f, 0f);
    }

    public void StartSpawnFloor()
    {
        int floorY = -6;
        for (int i = 0; i < floor_start; i++)
        {
            int number = Random.Range(0, 2);
            GameObject floorInit = Instantiate(FloorPrefabs[number], transform);
            floorInit.transform.position = new Vector3(Random.Range(-3.7f, 3.7f), floorY, 0f);
            floorY += 2;
        }
    }

}
