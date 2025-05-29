using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private ShipTeleport theTeleporter; // A private variable to hold the ShipTeleport script component for teleportation functionality

    public Transform tf; // A public variable to hold the Transform component of the player

    //Developer Notes:
    //Vector2 is a structure that represents a point in 2D space with x and y coordinates
    //While Vector3 is a structure that represents a point in 3D space with x, y, and z coordinates
    public Vector2 minPosition = new Vector2(-5, -5); // Minimum position for the player to stay within bounds x & y
    public Vector2 maxPosition = new Vector2(5, 5); // Maximum position for the player to stay within bounds x & y

    //Ship Speed Variables
    public float shipSpeed = 5f; // The default speed of the player's ship / pawn going forward or backwards.
    public float shipTurnSpeed = 5f; // The default turning / rotation speed of the player's ship / pawn.
    public float shipTurboSpeed = 10f; // The turbo speed of the ship, when activated by the player.

    //This is used for the teleportation functionality with the arrow keys, similar to the random teleport x & y limits above
    //public float teleportDistance = 2f; // The distance the player will teleport when using the arrow keys

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Call the TeleportDirections method from the ShipTeleport script to initialize teleportation functionality
        //GetComponent<ShipTeleport>().TeleportDirections(); 

        theTeleporter = gameObject.GetComponent<ShipTeleport>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) // An if statement that checks if the T key is pressed down (T for Teleport)
        {
            float randomX = Random.Range(minPosition.x, maxPosition.x); // Generate a random x position within bounds set above
            float randomY = Random.Range(minPosition.y, maxPosition.y); // Generate a random y position within bounds set above

            tf.position = new Vector2(randomX, randomY); // Set the player's ship sprite position to the new random position within the min / max bounds
        }

        //Need to call this in Update to continuously check for player input and movement every frame
        //Otherwise, the player ship will not move or respond to input.
        PlayerMovement(); // Call the PlayerMovement method to handle player input and movement

        //TeleportDirections(); // Call the TeleportDirections method to handle teleportation input
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

    //Note: Helpful reference https://docs.unity3d.com/6000.1/Documentation/ScriptReference/Vector2.html
    /*void TeleportDirections()
    {
        

        // This method is used to handle teleportation input from the player
        //This is the default position of the teleport arrow
        //Vector2.zero is shorthand for writing Vector2(0, 0).
        Vector2 teleportArrow = Vector2.zero;

        //used if else statements to check which arrow key is pressed
        if (Input.GetKeyDown(KeyCode.UpArrow))
            teleportArrow = Vector2.up;//Vector2.up is shorthand for writing Vector2(0, 1).
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            teleportArrow = Vector2.down;//Vector2.down is shorthand for writing Vector2(0, -1).
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            teleportArrow = Vector2.left;//Vector2.left is shorthand for writing Vector2(-1, 0).
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            teleportArrow = Vector2.right;//Vector2.right is shorthand for writing Vector2(1, 0).

        // Check if the teleportArrow is not zero, meaning an arrow key was pressed
        //This is also used to transform the player's position based on the teleportArrow direction
        if (teleportArrow != Vector2.zero)
        {
            Vector2 newPos2D = (Vector2)tf.position + teleportArrow * teleportDistance;
            tf.position = new Vector3(newPos2D.x, newPos2D.y, tf.position.z);
            //Transform the player's position to the new position based on the teleportArrow direction on the x,y, and z axes.
        }
    }*/

}
