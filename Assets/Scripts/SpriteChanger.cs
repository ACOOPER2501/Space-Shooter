
using System.Collections;
using System.Collections.Generic;
using UnityEngine; //UnityEngine core assets

public class SpriteChanger : MonoBehaviour // This script is used to change the sprite of a GameObject when it is clicked
{
    private SpriteRenderer theRenderer; // This declares the SpriteRenderer variable as a public component
    public Color SpriteColor; // A public variable for us to change the color of the player ship

    void Start() // Used for initialization
    {
        // This gets the SpriteRenderer script / component from the GameObject / sprite this is attached to
        theRenderer = gameObject.GetComponent<SpriteRenderer>(); 

        SpriteColor.a = 1.0f; // This sets the sprite color to alpha 1 (100% visibility)

        // Change the "color" value of our SpriteRenderer component to green
        theRenderer.color = SpriteColor; // This sets the color of the sprite to that of the variable spriteColor

        if (theRenderer != null) // If the SpriteRenderer component is not found
        {
            theRenderer.color = SpriteColor; // Set the color of the sprite to that of the variable spriteColor
        }
    }

    void Update() // Update is called once per frame
    {

    }
}
