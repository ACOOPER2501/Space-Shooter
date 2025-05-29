using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTeleport : MonoBehaviour
{

    public Transform tf; // A public variable to hold the Transform component of the player

    //This is used for the teleportation functionality with the arrow keys, similar to the random teleport x & y limits above
    public float teleportDistance = 2f; // The distance the player will teleport when using the arrow keys

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void TeleportDirections()
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

        // Check if the teleportArrow is not zero, meaning an arrow key was pressed
        //This is also used to transform the player's position based on the teleportArrow direction
        if (teleportArrow != Vector2.zero)
        {
            Vector2 newPos2D = (Vector2)tf.position + teleportArrow * teleportDistance;
            tf.position = new Vector3(newPos2D.x, newPos2D.y, tf.position.z);
            //Transform the player's position to the new position based on the teleportArrow direction on the x,y, and z axes.
        }
    }
}
