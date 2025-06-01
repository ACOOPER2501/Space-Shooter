using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float damageAmount;

    [SerializeField]
    private bool isInstaKill;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This method is called when the collider attached to this GameObject collides with another collider
    public void OnCollisionEnter2D(Collision2D otherObject)
    {
        // Check if the other object has a PlayerHealth component
        PlayerHealth healthComponent = otherObject.gameObject.GetComponent<PlayerHealth>();
        // If the other object has a PlayerHealth component, it means it's the player ship
        if (healthComponent != null)
        {
            if (isInstaKill)
            {
                // If isInstaKill is true, set damageAmount to the player's current health
                healthComponent.InstaKill(); // Call the InstaKill method from the PlayerHealth component
            }
            else
            {
                // If isInstaKill is false, deal the specified damage amount
                healthComponent.TakeDamage(damageAmount); // Call the TakeDamage method from the PlayerHealth component
            }

            PlayerHealth health = GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.InstaKill();
            }

            Destroy(gameObject); // Destroy this obstacle GameObject

        }

        Debug.Log("Is Hitting Object");
    }
}
