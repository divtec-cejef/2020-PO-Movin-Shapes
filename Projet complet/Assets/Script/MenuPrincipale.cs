using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuPrincipale : MonoBehaviour
{
    public Text text;
    private GameObject Manager;

    
    public void btn_change_scene (string scene_name)
    {
        GameManager.theName = text.text;

        SceneManager.LoadScene("Scene principale");
    }

    // Pour retourner au menu principale depuis la scène End_Screen
    public void btn_retourneMenu_scene(string scene_name)
    {
        SceneManager.LoadScene("Menu");
    }

    public void btn_endscreen_scene(string scene_name)
    {
        SceneManager.LoadScene("End_Screen");
    }

    public void btn_quitter_scene()
    {
        Application.Quit();
    }

}