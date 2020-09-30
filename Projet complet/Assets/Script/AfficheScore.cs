using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AfficheScore : MonoBehaviour
{
    public Text ScoreField;
    public Text TeamFied;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Score != null && GameManager.theName != null)
        {
            ScoreField.text = "" + GameManager.Score;
            TeamFied.text = GameManager.theName;
        }
    }


}
