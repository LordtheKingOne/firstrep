using UnityEngine;
using Unity.Collections;
using System.Collections;

public class faller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float lifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    IEnumerator MyCoroutine1()
    {
        yield return new WaitForSeconds(3);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Kill the player
            Debug.Log("Player hit by bullet!");
            Destroy(gameObject); // destroy bullet after hitting player
            StartCoroutine(MyCoroutine1());
            Destroy(other.gameObject); // or call player death function
            
        }
        // else do nothing — bullet just flies through other things
    }


}
