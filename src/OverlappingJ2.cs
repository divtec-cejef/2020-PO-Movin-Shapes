using UnityEngine;

public class OverlappingJ2 : MonoBehaviour
{
    private GameObject parentBall = null;

    private const int L_FOOTJ2 = 4;
    private const int R_FOOTJ2 = 3;
    private const int L_HANDJ2 = 6;
    private const int R_HANDJ2 = 5;
    private const int SPINEJ2 = 8;
    private const int HEADJ2 = 7;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject gameObjectOther = other.gameObject;
        parentBall = gameObjectOther.transform.parent.gameObject;

        //Regarde le nom parent si il est en erreur
        if (parentBall.name == "Error")
        {
            TimerLife.isWallHit = true;
        }
        else
        {
            //Regarde le tag de l'objet triggered et ajoute les points
            switch (other.tag)
            {
                case "LFoot":
                    if (!AddScore.listBallToucheJ2.Contains(L_FOOTJ2))
                    {
                        AddScore.listBallToucheJ2.Add(L_FOOTJ2);
                    };
                    break;
                case "RFoot":
                    if (!AddScore.listBallToucheJ2.Contains(R_FOOTJ2))
                    {
                        AddScore.listBallToucheJ2.Add(R_FOOTJ2);
                    };
                    break;
                case "LHand":
                    if (!AddScore.listBallToucheJ2.Contains(L_HANDJ2))
                    {
                        AddScore.listBallToucheJ2.Add(L_HANDJ2);
                    };
                    break;
                case "RHand":
                    if (!AddScore.listBallToucheJ2.Contains(R_HANDJ2))
                    {
                        AddScore.listBallToucheJ2.Add(R_HANDJ2);
                    };
                    break;
                case "Spine":
                    if (!AddScore.listBallToucheJ2.Contains(SPINEJ2))
                    {
                        AddScore.listBallToucheJ2.Add(SPINEJ2);
                    };
                    break;
                case "Head":
                    if (!AddScore.listBallToucheJ2.Contains(HEADJ2))
                    {
                        AddScore.listBallToucheJ2.Add(HEADJ2);
                    };
                    break;
            }
        }
    }
}
