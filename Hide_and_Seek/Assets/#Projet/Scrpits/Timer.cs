using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    double timer;
    bool createEnemy = false;
    GameObject enemy;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer);
        timer = Time.time;
        while (timer > 10 && !createEnemy)
        {
            enemy = Resources.Load("Enemy") as GameObject;
            Instantiate(enemy, spawnPoint);
            createEnemy = true;
        }
    }
}
