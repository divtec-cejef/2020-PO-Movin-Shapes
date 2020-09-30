using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        speed = TimerLife.doorSpeed;
        //La vitesse des portes
        Vector3 newPosition = new Vector3(6f, 0f, 0f);
        transform.Translate(newPosition * Time.deltaTime * speed);
    }
}