using System.Collections;
using System.Collections.Generic;
using UnityEngine; //allows access to Unity Engine assets and functions

public class SpriteScaler : MonoBehaviour
{
    private Transform tf; // A private variable for our transform script in the sprite's component
    public float maxScale; // Create a public variable for the max size we can scale

    // Use this for initialization / start
    void Start()
    {
        // Loads the component into the transform tf variable
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // 3.5 Notes: Check if the user has pressed the X key down in the console window
        if (Input.GetKeyDown(KeyCode.Space)) // An if statement that checks if the X key is pressed down
        {
            Debug.Log("The Space key is down!"); //Prints a message to the console if the X key is pressed down
        }
        //No else statement is needed here as we only want to log the message when the key is pressed.

        if (Input.GetButtonDown(("quit"))) //if statement checks if the quit button is pressed
        {
            Application.Quit(); //Quits the game
        }
        //No else statement is needed here as we only want to quit the game when the button is pressed.

        // The float value allows us to measure in decimals instead of being limited to whole numbers
        // 3.5 Notes: Find out how far and in which direction our axes are pressed via the user input
        float axesValue = Input.GetAxis("scale"); // This is set to scale between -1 and 1 
        
        float scaleAmount = axesValue * maxScale; // We multiply the axes value by the max scale to get the amount to scale
        //3.5 Notes: Increase the scale of our object by that amount on all axes (1,1,1) * scaleAmount
        tf.localScale += Vector3.one * scaleAmount; // We multiply the Vector3 by the scale amount to get the new scale
    }
}
