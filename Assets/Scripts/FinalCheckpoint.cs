using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCheckpoint : MonoBehaviour
{

    public GameObject previous;
    public Checkpoint[] checkpoints;
    public string tag;
    // Start is called before the first frame update

    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Checkpoint pc = previous.GetComponent<Checkpoint>();
        if (pc.is_active)
        {
            if (collider.tag == tag)
            {
                Debug.Log("cheguei");
                Car car = collider.GetComponent<Car>();
                car.current_lap += 1;
                if (car.current_lap > 3)
                {
                    Debug.Log(car.id + " WINS");
                }
                else if (car.current_lap <= 3)
                {
                    foreach (Checkpoint checkpoint in checkpoints)
                    {
                        checkpoint.is_active = false;
                    }

                    Debug.Log(car.id + " Lap: " + car.current_lap);
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
