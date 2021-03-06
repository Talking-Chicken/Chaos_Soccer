using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class score_system : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject soccer;
    public GameObject UI;
    public bool left;
    public bool right;
    public GameObject[] blue_team_firework;
    public GameObject[] red_team_firework;
    public AudioSource audioSource;
    public AudioClip win;
    public float volume = 0.5f;
    private bool can_score;
    void Start()
    {
        can_score = true;
        for (int i = 0; i < red_team_firework.Length; i++)
        {
            red_team_firework[i].GetComponent<ParticleSystem>().Stop();
        }
        for (int i = 0; i < blue_team_firework.Length; i++)
        {
            blue_team_firework[i].GetComponent<ParticleSystem>().Stop();


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name== "Soccer ball" && can_score)
        {
            UI.SetActive(false);
            StartCoroutine(ExampleCoroutine());
            can_score = false;
            if (left == true)
            {
                score_update.score_left = score_update.score_left + 1;
                Camera.main.transform.position = new Vector3(71.8f, 0f, -10);
                Camera.main.orthographicSize = 25;
                audioSource.PlayOneShot(win, volume);
                for (int i = 0; i < blue_team_firework.Length; i++)
                {
                    blue_team_firework[i].GetComponent<ParticleSystem>().Play();
                

                }
            }
            if (right == true) { 
                score_update.score_right = score_update.score_right + 1;
                audioSource.PlayOneShot(win, volume);
                Camera.main.transform.position = new Vector3(-81.1f, 0f, -10);
                Camera.main.orthographicSize = 25;
                for (int i = 0; i < red_team_firework.Length; i++)
                {
                    red_team_firework[i].GetComponent<ParticleSystem>().Play();
                }
            }
        }
    }
   
    void camera_reset()
    {
        Camera.main.transform.position = new Vector3(0,18,-10);
        Camera.main.orthographicSize = 80;
        for (int i = 0; i < red_team_firework.Length; i++)
        {
            red_team_firework[i].GetComponent<ParticleSystem>().Stop();
        }
        for (int i = 0; i < blue_team_firework.Length; i++)
        {
            blue_team_firework[i].GetComponent<ParticleSystem>().Stop();


        }
    }

IEnumerator ExampleCoroutine()
{

    //yield on a new YieldInstruction that waits for 2 seconds.
    yield return new WaitForSeconds(4f);
        UI.SetActive(true);
        can_score = true;
        soccer.transform.position = new Vector3(-4.5f, -14.21f, 0);
        soccer.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0); 
        soccer.GetComponent<Rigidbody2D>().freezeRotation = true;
        camera_reset();
        foreach (GameObject goat in TeamManager.team1)
        {
            goat.GetComponentInChildren<Athelete>().gameObject.transform.position=goat.GetComponentInChildren<Athelete>().spawnPos;
        }
        foreach (GameObject goat in TeamManager.team2)
        {
            goat.GetComponentInChildren<Athelete>().gameObject.transform.position = goat.GetComponentInChildren<Athelete>().spawnPos;
        }
    }
}
