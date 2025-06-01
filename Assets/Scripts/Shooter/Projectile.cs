using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 25f; // Designer-set in inspector

    // This method is called when the projectile enters a trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth health = collision.GetComponent<PlayerHealth>(); // Attempt to get the PlayerHealth component from the collided object
        if (health != null)
        {
            health.TakeDamage(damage);
            Destroy(gameObject); // Destroy bullet on hit
        }
    }
}
