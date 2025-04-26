using UnityEngine;

public class faller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float lifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // You can replace this with your own death logic
            Debug.Log("Player hit by bullet!");
            Destroy(other.gameObject); // or trigger death animation
        }

        // Destroy bullet on any collision
        Destroy(gameObject);
    }
    
}
