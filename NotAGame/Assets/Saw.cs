using UnityEngine;
using Unity.Collections;
using System.Collections;

public class Saw : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 3f;
    public float life = 7f;



    private Transform currentTarget;

    private void Start()
    {
        currentTarget = pointB; // Start moving toward pointB
        Destroy(gameObject, life);
    }

    private void Update()
    {
        // Move toward the current target
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        // Check if arrived
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.05f)
        {
            // Switch target
            currentTarget = currentTarget == pointA ? pointB : pointA;
        }
    }
    IEnumerator MyCoroutine1()
    {
        yield return new WaitForSeconds(3);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            StartCoroutine(MyCoroutine1());
            Destroy(other.gameObject); // or call your death animation
        }
    }
}
