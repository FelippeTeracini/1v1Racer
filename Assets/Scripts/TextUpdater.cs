using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{
    public GameManager gameManager;
    public Car player1;
    public Car player2;

    public Text lap1;
    public Text lap2;

    public Text victory1;
    public Text victory2;

    public Text restart1;
    public Text restart2;

    public Text countdown1;
    public Text countdown2;

    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        lap1.text = "Lap: " + player1.current_lap + "/3";
        lap2.text = "Lap: " + player2.current_lap + "/3";
        restart1.text = "Press Start or R to start";
        restart2.text = "Press Start or R to start";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.finished)
        {
            victory1.text = "Player " + gameManager.winner + " WINS!";
            restart1.text = "Press Start or R to restart";
            victory2.text = "Player " + gameManager.winner + " WINS!";
            restart2.text = "Press Start or R to restart";
        }
        if (player1.current_lap <= 3)
        {
            lap1.text = "Lap: " + player1.current_lap + "/3";
        }
        if (player2.current_lap <= 3)
        {
            lap2.text = "Lap: " + player2.current_lap + "/3";
        }
    }

    IEnumerator countdown_timer()
    {
        restart1.text = "";
        restart2.text = "";
        countdown1.text = "3";
        countdown2.text = "3";
        audioManager.Play("beep");
        yield return new WaitForSeconds(1f);
        countdown1.text = "2";
        countdown2.text = "2";
        audioManager.Play("beep");
        yield return new WaitForSeconds(1f);
        countdown1.text = "1";
        countdown2.text = "1";
        audioManager.Play("beep");
        yield return new WaitForSeconds(1f);
        countdown1.text = "GO!";
        player1.started = true;
        countdown2.text = "GO!";
        player2.started = true;
        audioManager.Play("final_beep");
        yield return new WaitForSeconds(0.5f);
        countdown1.text = "";
        countdown2.text = "";
    }
}
