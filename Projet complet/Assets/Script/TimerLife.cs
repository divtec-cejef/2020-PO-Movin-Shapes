using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerLife : MonoBehaviour
{
    public float timeRemaining = 30;
    public float timeScoring = 0;
    
    public static int nbreVie = 6;
    public static float doorSpeed = 0.5f;
    public static int doorCounted = 0;
    public static bool isWallHit = false;
    public static bool isDoorDifferent = true;

    public float speedy = 0;
    private bool timerIsRunning = false;
    private int doorCreated = 4;
    private GameObject doorToGetTL = null;
    private GameObject ancientDoorTL = null;
    private GameObject childDoor = null;
    private Material doorMaterial;
    private AudioSource audioSource;

    private const int VITESSE_MAX = 3;
    private const float ACCELERATION = 0.3f;

    private void Start()
    {
        // Commence le timer automatiquement
        timerIsRunning = true;
        doorSpeed = 0.5f;
        nbreVie = 6;
    }

    void Update()
    {
        audioSource = GetComponent<AudioSource>();
        speedy = doorSpeed;
        if (timerIsRunning)
        {
            // Fonction gérant le timer de début
            RunTimer();
        }
        else
        {
            // Fonction gérant la vitesse des portes
            ManageSpeed();
        }

        //Si la touche Escape est appuyé, on retourne sur la page de fin
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("End_Screen");
        }

        //Regarde si la porte touchée est la même
        doorToGetTL = InstantiateDoors.doorToDestroy;
        if (doorToGetTL != ancientDoorTL)
        {
            isDoorDifferent = true;
            ancientDoorTL = doorToGetTL;
        }

        // Fonction gérant les vies
        ManageLife();
    }

    /// <summary>
    /// Fonction gérant le chronomètre de départ
    /// </summary>
    public void RunTimer()
    {
        // Fait un timer avant le début du jeu
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            doorCounted = 0;
        }
        else
        {
            //stop le timer
            UnityEngine.Debug.Log("Time has run out!");
            timeRemaining = 0;
            timerIsRunning = false;
        }
    }

    /// <summary>
    /// Fonction gérant la vitesse des portes
    /// </summary>
    public void ManageSpeed()
    {
        //Le timer pour le score est en route
        timeScoring += Time.deltaTime;
        //Contrôle le nombre de porte et la vitesse
        if (!(doorSpeed >= VITESSE_MAX) && doorCreated == doorCounted)
        {
            doorSpeed += ACCELERATION;
            doorCreated += 4;
        }
    }

    /// <summary>
    /// Fonction gérant les vies des joueurs
    /// Changeant la scène lorsque le nombre de vie est égale à 0
    /// </summary>
    public void ManageLife()
    {
        
        if (isWallHit && !timerIsRunning)
        {
            if (nbreVie == 0)
            {
                SceneManager.LoadScene("End_Screen");
            }
            //Si ce n'est pas le cas, une vie est enlevée
            else if (isDoorDifferent)
            {
                audioSource.Play();
                nbreVie--;
                isDoorDifferent = false;
            }

            if (doorToGetTL != null)
            {
                // Regarde le tag de l'objet-enfant de la porte pour changer la couleur
                foreach (Transform child in doorToGetTL.transform)
                {
                    if (child.CompareTag("Child"))
                    {
                        doorMaterial = child.gameObject.GetComponent<Renderer>().material;
                        doorMaterial.color = Color.red;
                    }
                }
                doorMaterial = doorToGetTL.GetComponent<Renderer>().material;
                doorMaterial.color = Color.red;
            }
        }
    }
}
