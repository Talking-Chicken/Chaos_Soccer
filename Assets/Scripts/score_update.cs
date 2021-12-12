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
    public AudioSource audioSource;
    public AudioClip win;
    public AudioClip tie;
    public AudioClip play_sound;
    public TextMeshProUGUI score_1;
    public TextMeshProUGUI score_2;
    public TextMeshProUGUI count_down;
    public Sprite draw;
    public Sprite blue;
    public Sprite red;
    public GameObject result_UI;
    public float volume = 0.5f;
    public GameObject disable_UI;
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        score_1.text = score_left.ToString();
        score_2.text = score_right.ToString();
        if (score_left==10)
        {
            result_UI.SetActive(true);
            timerIsRunning = false;
            result_UI.GetComponent<Image>().sprite = blue;
        }
        if (score_right == 10)
        {
            result_UI.SetActive(true);
            timerIsRunning = false;
            result_UI.GetComponent<Image>().sprite = red;
        }

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
                if (score_left==score_right)
                {
                    result_UI.SetActive(true);
                    result_UI.GetComponent<Image>().sprite = draw;
                    audioSource.PlayOneShot(tie, volume);
                }
                if (score_right>score_left)
                {
                    result_UI.SetActive(true);
                    result_UI.GetComponent<Image>().sprite = red;
                    audioSource.PlayOneShot(win, volume);
                }
                if (score_right < score_left)
                {
                    result_UI.SetActive(true);
                    result_UI.GetComponent<Image>().sprite = blue;
                    audioSource.PlayOneShot(win, volume);
                }

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
    IEnumerator ExampleCoroutine()
    {


        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        disable_UI.SetActive(false);
        audioSource.PlayOneShot(play_sound,volume);
        timerIsRunning = true;
    }
}
