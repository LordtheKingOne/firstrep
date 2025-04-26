using UnityEngine;

public class DangerZone : MonoBehaviour
{
    public Transform playerLocation;
    public float detectionRadius = 2f;
    public float timeToKill = 4f;

    public float timer = 0f;

    void Update()
    {
        if (Vector2.Distance(transform.position, playerLocation.position) <= detectionRadius)
        {
            timer += Time.deltaTime;

            if (timer >= timeToKill)
            {
                Debug.Log("Player stayed too long. You died!");
                //Destroy(playerLocation.gameObject); // Or call your death method
            }
        }
        else
        {
            timer = 0f; // Reset timer if player leaves
        }
    }
}
