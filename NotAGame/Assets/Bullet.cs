using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifeTime); // Bullet destroys itself after some time
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit by bullet!");
            Destroy(other.gameObject); // or trigger death animation
            Destroy(gameObject); // destroy bullet ONLY when it hits the player
        }
    }
}
