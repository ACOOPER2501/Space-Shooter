using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public PlayerPawn playerPawn; // A reference to the PlayerPawn script, which handles the player's ship / pawn

    public Transform tf; // A public variable to hold the Transform component of the player

    //Ship Speed Variables
    public float shipSpeed = 5f; // The default speed of the player's ship / pawn going forward or backwards.
    public float shipTurnSpeed = 5f; // The default turning / rotation speed of the player's ship / pawn.
    public float shipTurboSpeed = 10f; // The turbo speed of the ship, when activated by the player.

    public KeyCode Shoot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        if (playerPawn != null) // Check if the playerPawn reference is assigned in the Inspector
        {
            playerPawn.PrintHello(); // Call the PrintHello method from the PlayerPawn script
        }

        PlayerMovement(); // Call the PlayerMovement method to handle player input and movement

        if (Input.GetKeyDown(Shoot)) // Check if the Shoot key is pressed down
        {
            playerPawn.Shoot(); // Call the Shoot method from the PlayerPawn script to handle shooting
        }

    }

    //Note: Used with the help of Unity Documentation and tutorials, such as the Transform.Rotate article.
    // This method is used to move the player ship / pawn based on input from the keyboard
    void PlayerMovement()
    {
        //Note: f is used with float values to indicate that these are floating-point numbers
        //Otherwise, they would be treated as double by default in C# and cause an error.
        float inputMovement = 0f; // A variable to hold the input movement value to go forward or backward
        float inputRotation = 0f; // A variable to hold the input rotation value to go left or right

        //Note: Input.GetKey is used to check if a key is currently being pressed down
        //GetKeyDown, however, is used to check if a key was pressed down in the current frame only.
        //So, using GetKeyDown would have the player tap the key repeatedly to move, which is not ideal for continuous movement.
        if (Input.GetKey(KeyCode.W)) inputMovement += 1f; // Increase ship forward speed when W key is held down
        if (Input.GetKey(KeyCode.S)) inputMovement -= 1f; // Decrease ship reverse speed when S key is held down
        if (Input.GetKey(KeyCode.A)) inputRotation += 1f; // Set rotation to left when A key is held down
        if (Input.GetKey(KeyCode.D)) inputRotation -= 1f; // Set rotation to right when D key is held down

        
        float speed; // A variable to hold the current speed of the ship
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) //using || (Meaning Or) to check if either left or right Shift key is pressed
        { //Both shift keys will have the same functionality
            speed = shipTurboSpeed; //if shift key is pressed, set speed to turbo speed
        }
        else
        {
            speed = shipSpeed; //if shift key is not pressed, set speed to normal ship speed
        }

        //Note: Need to use Vector3, even in a 2D project, because Unity's Transform component operates in 3D space.
        //So, we convert Vector2 to Vector3 for movement and rotation calculations.
        // Local forward movement in 2D (Vector2 converted to Vector3)
        Vector2 moveAmount = Vector2.up * inputMovement * speed * Time.deltaTime; //This is how movement speed is calculated in Unity
        tf.Translate((Vector3)moveAmount, Space.Self);

        // Rotate around Z axis, which requires a Vector3 rotation
        float rotationAmount = inputRotation * shipTurnSpeed * Time.deltaTime; //This is how rotation speed is calculated in Unity
        tf.Rotate(Vector3.forward * rotationAmount);

    }


}
