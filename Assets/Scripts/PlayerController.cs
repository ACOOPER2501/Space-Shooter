using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Transform tf; // A private variable to hold the Transform component of the player

    //Developer Notes:
    //Vector2 is a structure that represents a point in 2D space with x and y coordinates
    //While Vector3 is a structure that represents a point in 3D space with x, y, and z coordinates
    public Vector2 minPosition = new Vector2(-5, -5); // Minimum position for the player to stay within bounds x & y
    public Vector2 maxPosition = new Vector2(5, 5); // Maximum position for the player to stay within bounds x & y

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = GetComponent<Transform>(); // Initialize the tf variable with the Transform component of this GameObject
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
    }
}
