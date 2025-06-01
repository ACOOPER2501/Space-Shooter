using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] // This attribute allows private fields to be visible in the Unity Inspector
    private float maxHealth; // Player's maximum health, set to 100 by default

    [SerializeField] // This attribute allows private fields to be visible in the Unity Inspector
    private float currentHealth; // Player's current health, initialized to maxHealth

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //Heal(5);
        //TakeDamage(100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Heal(float amount)
    {
        currentHealth = currentHealth + amount;
        //Using currentHealth += amount; would also work the same way

        if (currentHealth > maxHealth) // Check if current health exceeds maximum health
        {
            currentHealth = maxHealth; // If it does, set current health to maximum health number
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth = currentHealth - amount;
        //Using currentHealth -= amount; would also work the same way
        
        if (currentHealth <= 0) // Check if current health is less than or equal to zero
        {
            currentHealth = 0; // If it is, set current health to zero. This is to avoid negative health values

            InstaKill();
            
        }
    }

    public void InstaKill()
    {
        Death deathComponent = GetComponent<Death>();

        if (deathComponent != null)
        {
            deathComponent.Die(); // Call the Die method from the Death component if it exists

            Debug.Log("Player Ship Destroyed.");
        }
    }

    //Note: bool is a data type in C# that can only be true or false
    public bool IsAlive()
    {
        // if our health is greater than zero
        if (currentHealth > 0)
        {
            return true;
        }

        // otherwise, return false
        return false;
    }


    //Note for self: Using public also allows the variable to be visible and editable in the Unity Inspector

}
