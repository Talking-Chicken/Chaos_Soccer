using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class score_system : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject soccer;
    public bool left;
    public bool right;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name== "Soccer ball")
        {
            Debug.Log("test");
            StartCoroutine(ExampleCoroutine());
            if (left == true)
            {
                score_update.score_left = score_update.score_left + 1;
            }
            if (right == true) { 
                score_update.score_right = score_update.score_right + 1;
            }
        }
    }
   


IEnumerator ExampleCoroutine()
{

    //yield on a new YieldInstruction that waits for 5 seconds.
    yield return new WaitForSeconds(1);
        soccer.transform.position = new Vector3(-4.5f,0,0);
}
}
