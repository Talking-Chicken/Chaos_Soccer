using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goat_animation : MonoBehaviour
{
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    IEnumerator ExampleCoroutine()
    {
       

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        int randomNumber = Random.Range(0, 3);

        if (randomNumber == 0)
        {
            m_Animator.SetTrigger("0");
        }
        if (randomNumber == 1)
        {
            m_Animator.SetTrigger("1");
        }
        if (randomNumber == 2)
        {
            m_Animator.SetTrigger("2");
        }
        StartCoroutine(ExampleCoroutine());
    }
}
