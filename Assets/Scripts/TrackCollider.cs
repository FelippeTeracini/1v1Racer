using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "car1" || collider.tag == "car2")
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            rb.drag = 0.8f;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "car1" || collider.tag == "car2")
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            rb.drag = 2.4f;
        }
    }
}
