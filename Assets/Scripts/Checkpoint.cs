using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public bool is_active = false;
    public GameObject previous;
    public string tag;

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (!is_active)
        {
            if (collider.tag == tag)
            {
                Debug.Log("Checkpoint");
                Checkpoint pc = previous.GetComponent<Checkpoint>();
                if (pc.is_active)
                {
                    is_active = true;
                }
            }
        }
    }

}
