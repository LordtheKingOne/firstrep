using UnityEngine;

public class rotate : MonoBehaviour
{
    public float rotationSpeed = 90f; // degrees per second
    
    public float sawspeed = 5f;
    public float lifeTime = 12f;

    private Vector3 targetPosition;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
        
    }

    void Update()
    {
        // Rotate the saw
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        // Move between left and right
        

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit by saw!");
            Destroy(other.gameObject); // or trigger death animation
        }
    }
}
