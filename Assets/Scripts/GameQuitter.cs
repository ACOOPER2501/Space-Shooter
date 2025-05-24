using System.Collections;
using System.Collections.Generic;
using UnityEngine; // Importing necessary UnityEngine namespaces

public class GameQuitter : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(("quit"))) //if statement checks if the quit button is pressed
        {
            Application.Quit (); //Quits the game
        }
        //No else statement is needed here as we only want to quit the game when the button is pressed.
    }
}
