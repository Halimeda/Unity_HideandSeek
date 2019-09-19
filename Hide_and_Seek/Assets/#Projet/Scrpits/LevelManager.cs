using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject enemy;
    public GameObject player;
    public float arrivalTime = 10f;
    private float timer = 0f;
    public Text timerText;
    public GameObject[] destination;

    //bool createEnemy = false;
    //private float time = 0f;
    //private float arrivalTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnemy());
        if(player == null)
        {
            Debug.Log("No player set in LevelManager!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = timer.ToString("000.0");
        //time += Time.deltaTime;
        //if(time >= arrivalTime && !createEnemy)
        //{
            //createEnemy();
        //}
    }

    //void CreateEnemy()
    //{
    //        enemy = Resources.Load("Enemy") as GameObject;
    //        Instantiate(enemy, spawnPoint.transform);
    //        createEnemy = true;
    //}

    IEnumerator CreateEnemy()
    {
        yield return new WaitForSeconds(arrivalTime);
        enemy = Instantiate(enemyPrefab);
        MoveEnemy enemyComponent = enemy.GetComponent<MoveEnemy>();
        enemyComponent.manager = this;
        enemyComponent.player = this.player;
    }

    public void GameOver()
    {
        Score.value = timer;
        SceneManager.LoadScene("Game_over");
    }
}
