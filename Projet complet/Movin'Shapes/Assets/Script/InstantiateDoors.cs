using System.Collections.Generic;
using UnityEngine;

public class InstantiateDoors : MonoBehaviour
{
    // GameObject Porte
    public GameObject doorPiedLeve;
    public GameObject doorAssis;
    public GameObject doorDebout;
    public GameObject doorX;
    public GameObject doorDeboutAssis;
    public GameObject doorTPose;
    public GameObject doorMainLeve;
    public GameObject doorAssisDebout;
    public GameObject doorDeboutCoteExt;
    public GameObject doorDeboutCoteInt;

    public static GameObject doorToDestroy;
    public static List<GameObject> listDoorsInstantiated;

    private List<GameObject> listDoors;
    private int maxDoorsToCreate = 2;

    private const int SPACE_BTW_DOORS = 20f;
    private const float POSITION_Z_PASSED = 0.5f;
    private const float POSITION_Z_DESTROY = -8.0f;

    // Start is called before the first frame update
    void Start()
    {
        listDoors = new List<GameObject>();
        listDoorsInstantiated = new List<GameObject>();

        // Ajout des portes dans la liste
        listDoors.Add(doorAssis);
        listDoors.Add(doorDebout);
        listDoors.Add(doorDeboutAssis);
        listDoors.Add(doorMainLeve);
        listDoors.Add(doorPiedLeve);
        listDoors.Add(doorTPose);
        listDoors.Add(doorX);
        listDoors.Add(doorAssisDebout);
        listDoors.Add(doorDeboutCoteExt);
        listDoors.Add(doorDeboutCoteInt);
    }

    // Update is called once per frame
    void Update()
    {
        // Crée les portes
        CreateDoor(listDoorsInstantiated, listDoors);

        // Détruit les portes
        DestroyDoor(listDoorsInstantiated);
    }

    /// <summary>
    /// Fonction créant les portes et les plaçant sur le jeu
    /// </summary>
    /// <param name="listDoorsInstantiated">Liste des portes instanciées dans le jeu</param>
    /// <param name="listDoors">Liste des portes pouvant être créées</param>
    void CreateDoor(List<GameObject> listDoorsInstantiated, List<GameObject> listDoors)
    {
        // Initialisation du Random
        System.Random random = new System.Random();

        for (int doorsInstantiated = listDoorsInstantiated.Count; doorsInstantiated < maxDoorsToCreate; doorsInstantiated++)
        {

            // Génère un nombre aléatoire
            int indexRandom = random.Next(listDoors.Count);

            // Instantie une nouvelle porte
            GameObject door = null;
            door = Instantiate(listDoors[indexRandom]);
            door.name = listDoors[indexRandom].name;

            // Compte le nombre de porte créées
            if ((doorsInstantiated % 4) <= 1)
            {
                TimerLife.doorCounted++;
            }

            // Met la position de la porte
            float positionZ = SPACE_BTW_DOORS * (doorsInstantiated + 1);
            door.transform.position = new Vector3(-1.5f, 0f, positionZ);

            // Ajoute le script de mouvement
            door.AddComponent<Movement>();

            listDoorsInstantiated.Add(door);
        }
    }

    /// <summary>
    /// Fonction détruisant les portes lors du passage d'un certain point
    /// </summary>
    /// <param name="listDoorsInstantiated">Liste des portes instanciées dans le jeu</param>
    void DestroyDoor(List<GameObject> listDoorsInstantiated)
    {
        for (int indexDoorsToDestroy = 0; indexDoorsToDestroy < listDoorsInstantiated.Count; indexDoorsToDestroy++)
        {
            if (listDoorsInstantiated.Count >= 1)
            {
                if (listDoorsInstantiated[indexDoorsToDestroy] != null)
                {
                    //Ajoute la porte passant 0 en position Z dans la porte à détruire
                    if (listDoorsInstantiated[indexDoorsToDestroy].transform.position.z < POSITION_Z_PASSED)
                    {
                        doorToDestroy = listDoorsInstantiated[indexDoorsToDestroy];
                        listDoorsInstantiated.RemoveAt(indexDoorsToDestroy);
                        AddScore.addPoints = true;
                    }
                }

                //Détruit la porte si elle se trouve en dessous de -8 en position Z
                if (doorToDestroy != null)
                {
                    if (doorToDestroy.transform.position.z < POSITION_Z_DESTROY)
                    {
                        TimerLife.isWallHit = false;
                        Destroy(doorToDestroy);
                    }
                }
            }
        }
    }
}