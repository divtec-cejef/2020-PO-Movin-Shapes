using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{

    public static int Score = 0;
    public static string theName = "";


    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


