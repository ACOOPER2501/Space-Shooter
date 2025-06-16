using UnityEngine;
using UnityEngine.UI; // Required for using UI components like Image

public class Asteroid : MonoBehaviour
{

    //Changed to public so that it could be called from other scripts without needing to use GetComponent<PlayerHealth>().
    public float asteroidMaxHealth; // Player's maximum health, set to 100 by default

    //Changed to public so that it could be called from other scripts without needing to use GetComponent<PlayerHealth>().
    public float asteroidCurrentHealth; // Player's current health, initialized to maxHealth

    public Image asteroidHealthBarImage; // Reference to the UI Image component that represents the health bar

    private DeathTarget DeathTarget; // Reference to the DeathTarget component, which handles the death logic for this asteroid

    public float speed; // Speed of the asteroid, can be set in the Inspector

    public Rigidbody2D rb; // Reference to the Rigidbody2D component for physics interactions

    public float moveSpeed; // Speed at which the asteroid moves, can be set in the Inspector

    public Vector2 moveDirection = Vector2.down; // Direction in which the asteroid moves, initialized to downwards

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DeathTarget = GetComponent<DeathTarget>(); // Get the DeathTarget component attached to this GameObject

        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to this GameObject
    }

    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // This method is called every frame, but we will use FixedUpdate for physics-related updates
        Vector2 newPosition = rb.position + moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition); // Move the asteroid in the specified direction at the defined speed
    }

    public void AsteroidHeal(float amount)
    {
        asteroidCurrentHealth = asteroidCurrentHealth + amount;
        //Using currentHealth += amount; would also work the same way

        if (asteroidCurrentHealth > asteroidMaxHealth) // Check if current health exceeds maximum health
        {
            asteroidCurrentHealth = asteroidMaxHealth; // If it does, set current health to maximum health number
        }

        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        asteroidCurrentHealth -= amount;

        if (asteroidCurrentHealth <= 0) // Check if current health is less than or equal to zero
        {
            asteroidCurrentHealth = 0; // If it is, set current health to zero. This is to avoid negative health values

            DeathTarget.Die();

        }

        UpdateHealthBar();
    }

    public void InstaKill()
    {

        if (DeathTarget != null)
        {
            DeathTarget.Die(); // Call the Die method from the Death component if it exists

            Debug.Log("Asteroid Destroyed.");
        }
        else
        {
            Debug.LogWarning("Death component not found on Asteroid."); // Log a warning if the Death component is not found
        }

        UpdateHealthBar();
    }

    // This method updates the health bar UI based on the current health
    public float ComputeHealthPercentage()
    {
        return asteroidCurrentHealth / asteroidMaxHealth; // Calculate the health percentage by dividing current health by maximum health
    }

    public void UpdateHealthBar()
    {
        if (asteroidHealthBarImage != null) // Check if the health bar image reference is assigned in the Inspector
        {
            asteroidHealthBarImage.fillAmount = ComputeHealthPercentage(); // Update the health bar UI based on the current health percentage
        }
    }

    //Note: bool is a data type in C# that can only be true or false
    public bool IsAlive()
    {
        // if our health is greater than zero
        if (asteroidCurrentHealth > 0)
        {
            return true;
        }

        // otherwise, return false
        return false;
    }


}
