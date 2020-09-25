using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Car player1;
    public Car player2;
    public bool finished = false;
    public int winner;
    public bool started = false;
    public TextUpdater textUpdater;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!started && Input.GetButton("Restart"))
        {
            started = true;
            textUpdater.StartCoroutine("countdown_timer");
        }
        if (Input.GetButton("Restart") && finished)
        {
            SceneManager.LoadScene("Race");
        }
        if (player1.current_lap > 3 && !finished)
        {
            finished = true;
            winner = player1.id;
        }
        else if (player2.current_lap > 3 && !finished)
        {
            finished = true;
            winner = player2.id;
        }
    }
}
