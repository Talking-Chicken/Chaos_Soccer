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

    public TextMeshProUGUI score_1;
    public TextMeshProUGUI score_2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score_1.text = score_left.ToString();
        score_2.text = score_right.ToString();
    }
}
