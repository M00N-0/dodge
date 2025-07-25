using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{
    private float time;
    private bool isGameOver;

    public GameObject gameOverText;
    public Text timeText;
    public Text bestTimeText;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            time += Time.deltaTime;
            timeText.text = "Time : " + ((int)time);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

        public void EndGame()
    {
        isGameOver = true;
        gameOverText.SetActive(true);

        float bestTime;

        if (!PlayerPrefs.HasKey("BestTime")) { bestTime = 0f; }
        else
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");
        }

        if(time > bestTime)
        {
            bestTime = time;
            PlayerPrefs.SetFloat("BestTime", bestTime); 
        }

        bestTimeText.text = "Best Time : " + bestTime;

    }
}
