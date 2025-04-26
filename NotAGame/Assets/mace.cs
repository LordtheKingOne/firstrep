using UnityEngine;

public class mace : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // You can replace this with your own death logic
            Debug.Log("Player hit by bullet!");
            Destroy(other.gameObject); // or trigger death animation
        }
        
    }
}
