using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score : " + Score.value.ToString("000.0");
        StartCoroutine(Relaunch());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Relaunch()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Start");
    }
}
