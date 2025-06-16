using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage; // Designer-set in inspector

    void Start()
    {
        // Set the projectile to destroy itself after 2 seconds if it doesn't hit anything
        Destroy(gameObject, 2f);
    }


    // This method is called when the projectile enters a trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Asteroid asteroid = collision.GetComponent<Asteroid>(); // Attempt to get the Asteroid component from the collided object

        if (asteroid != null)
        {
            asteroid.TakeDamage(damage);
            Destroy(gameObject); // Destroy bullet on hit
            return;
        }
    }

}
