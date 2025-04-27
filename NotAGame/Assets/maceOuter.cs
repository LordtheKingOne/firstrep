using UnityEngine;
using Unity.Collections;
using System.Collections;

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
    IEnumerator MyCoroutine1()
    {
        yield return new WaitForSeconds(3);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // You can replace this with your own death logic
            Debug.Log("Player hit by mace!");
            StartCoroutine(MyCoroutine1());
            Destroy(other.gameObject); // or trigger death animation
        }

    }
}
