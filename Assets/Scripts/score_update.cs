using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score_update : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score_left=0;
    public static int score_right=0;
    public float timeRemaining = 120;
    public bool timerIsRunning = false;

    public TextMeshProUGUI score_1;
    public TextMeshProUGUI score_2;
    public TextMeshProUGUI count_down;
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        score_1.text = score_left.ToString();
        score_2.text = score_right.ToString();
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            count_down.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
