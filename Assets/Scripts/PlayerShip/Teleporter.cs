using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public Transform tf; // A public variable to hold the Transform component of the player

    //This is used for the teleportation functionality with the arrow keys, similar to the random teleport x & y limits above
    public float teleportDistance = 2f; // The distance the player will teleport when using the arrow keys

    //Developer Notes:
    //Vector2 is a structure that represents a point in 2D space with x and y coordinates
    //While Vector3 is a structure that represents a point in 3D space with x, y, and z coordinates
    public Vector2 minPosition = new Vector2(-5, -5); // Minimum position for the player to stay within bounds x & y
    public Vector2 maxPosition = new Vector2(5, 5); // Maximum position for the player to stay within bounds x & y

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    {
        TeleportDirections(); // Call the TeleportDirections method to handle teleportation input

        if (Input.GetKeyDown(KeyCode.T)) // An if statement that checks if the T key is pressed down (T for Teleport)
        {
            float randomX = Random.Range(minPosition.x, maxPosition.x); // Generate a random x position within bounds set above
            float randomY = Random.Range(minPosition.y, maxPosition.y); // Generate a random y position within bounds set above

            tf.position = new Vector2(randomX, randomY); // Set the player's ship sprite position to the new random position within the min / max bounds
        }

    }

    //Note: Helpful reference https://docs.unity3d.com/6000.1/Documentation/ScriptReference/Vector2.html
    void TeleportDirections()
    {


        //This method is used to handle teleportation input from the player
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

        //Check if the teleportArrow is not zero, meaning an arrow key was pressed
        //This is also used to transform the player's position based on the teleportArrow direction
        if (teleportArrow != Vector2.zero)
        {
            Vector2 newPos2D = (Vector2)tf.position + teleportArrow * teleportDistance;
            tf.position = new Vector3(newPos2D.x, newPos2D.y, tf.position.z);
            //Transform the player's position to the new position based on the teleportArrow direction on the x,y, and z axes.
        }
    }
}
