using UnityEngine;

public class OverlappingJ1 : MonoBehaviour
{
    private GameObject parentBall = null;

    private const int L_FOOTJ1 = 3;
    private const int R_FOOTJ1 = 4;
    private const int L_HANDJ1 = 5;
    private const int R_HANDJ1 = 6;
    private const int SPINEJ1 = 8;
    private const int HEADJ1 = 7;

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
        if (parentBall.name == "Error" || TimerLife.isWallHit)
        {
            TimerLife.isWallHit = true;
        }
        else
        {
            //Regarde le tag de l'objet triggered et ajoute les points
            switch (other.tag)
            {
                case "LFoot":
                    if (!AddScore.listBallToucheJ1.Contains(L_FOOTJ1))
                    {
                        AddScore.listBallToucheJ1.Add(L_FOOTJ1);
                    };
                    break;
                case "RFoot":
                    if (!AddScore.listBallToucheJ1.Contains(R_FOOTJ1))
                    {
                        AddScore.listBallToucheJ1.Add(R_FOOTJ1);
                    };
                    break;
                case "LHand":
                    if (!AddScore.listBallToucheJ1.Contains(L_HANDJ1))
                    {
                        AddScore.listBallToucheJ1.Add(L_HANDJ1);
                    };
                    break;
                case "RHand":
                    if (!AddScore.listBallToucheJ1.Contains(R_HANDJ1))
                    {
                        AddScore.listBallToucheJ1.Add(R_HANDJ1);
                    };
                    break;
                case "Spine":
                    if (!AddScore.listBallToucheJ1.Contains(SPINEJ1))
                    {
                        AddScore.listBallToucheJ1.Add(SPINEJ1);
                    };
                    break;
                case "Head":
                    if (!AddScore.listBallToucheJ1.Contains(HEADJ1))
                    {
                        AddScore.listBallToucheJ1.Add(HEADJ1);
                    };
                    break;
            }
        }
    }
}
