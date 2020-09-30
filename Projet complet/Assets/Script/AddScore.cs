using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kinect = Windows.Kinect;

public class AddScore : MonoBehaviour
{
    public Text textScore;
    public Text textVies;

    public static bool addPoints = false;
    public static List<int> listBallToucheJ1;
    public static List<int> listBallToucheJ2;

    private int nbrePointsJ1 = 0;
    private int nbrePointsJ2 = 0;
    private int score = 0;

    private const float POSITION_Z_BEHIND = -2.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Initialisation
        textScore.text = "Score: " + GameManager.Score;
        listBallToucheJ1 = new List<int>();
        listBallToucheJ2 = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        //Affichage des vies
        textVies.text = "Vie(s): " + TimerLife.nbreVie;

        if (TimerLife.isWallHit == false)
        {
            if (InstantiateDoors.doorToDestroy != null)
            {
                if (addPoints && InstantiateDoors.doorToDestroy.transform.position.z <= POSITION_Z_BEHIND)
                {
                    for (int pointsJ1 = 0; pointsJ1 < listBallToucheJ1.Count; pointsJ1++)
                    {
                        nbrePointsJ1 += listBallToucheJ1[pointsJ1];
                    }

                    for (int pointsJ2 = 0; pointsJ2 < listBallToucheJ2.Count; pointsJ2++)
                    {
                        nbrePointsJ2 += listBallToucheJ2[pointsJ2];
                    }

                    // Ajout des points de chaque joueur
                    GameManager.Score += nbrePointsJ1 + nbrePointsJ2;
                    
                    // Réinitialisation des valeurs
                    addPoints = false;
                    listBallToucheJ1.Clear();
                    listBallToucheJ2.Clear();
                    nbrePointsJ1 = 0;
                    nbrePointsJ2 = 0;
                    
                }
            }
            textScore.text = "Score: " + GameManager.Score;
        }
    }
}