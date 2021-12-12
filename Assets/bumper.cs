using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumper : MonoBehaviour
{
    // Start is called before the first frame update
    Animator m_Animator;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    public GameObject star;
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name== "Soccer ball")
        {
            m_Animator.SetTrigger("hit");
            audioSource.PlayOneShot(clip, volume);
            Instantiate(star, collision.transform.position, Quaternion.identity);
        }
    }
}
