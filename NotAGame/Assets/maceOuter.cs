using UnityEngine;

public class MaceOuter : MonoBehaviour
{
    public float rotationSpeedMace = 90f; // degrees per second
    public float lifeTimeMace = 15f;
   
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeedMace * Time.deltaTime);

    }
    

    private void Start()
    {
        Destroy(gameObject, lifeTimeMace);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // You can replace this with your own death logic
            Debug.Log("Player hit by mace!");
            Destroy(other.gameObject); // or trigger death animation
        }

    }
}
