using UnityEngine;

public class rotate : MonoBehaviour
{
    public float rotationSpeed = 90f; // degrees per second
    public GameObject ltrans;
    public GameObject rtrans;
    public float sawspeed = 5f;
    public float lifeTime = 5f;

    private Vector3 targetPosition;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
        targetPosition = rtrans.transform.position; // start moving to right
    }

    void Update()
    {
        // Rotate the saw
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        // Move between left and right
        { transform.position = Vector3.MoveTowards(transform.position, targetPosition, sawspeed * Time.deltaTime);
        targetPosition = ltrans.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, sawspeed * Time.deltaTime);
        targetPosition = rtrans.transform.position; }

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (targetPosition == rtrans.transform.position)
                targetPosition = ltrans.transform.position;
            else
                targetPosition = rtrans.transform.position;
        }
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
