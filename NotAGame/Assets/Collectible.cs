using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;
    public AudioClip collect;
    private BoxCollider2D col;
    private SpriteRenderer spr;

    private void Start()
    {   
        col = GetComponent<BoxCollider2D>();
        spr = GetComponent<SpriteRenderer>();
        SFXSource.clip = collect;   
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindAnyObjectByType<ScoreManager>().AddPoint();
            SFXSource.Play();
            StartCoroutine(DestroyAfterSound());
        }
    }
    IEnumerator DestroyAfterSound()
    {
        col.enabled = false;
        spr.enabled = false;  
        yield return new WaitForSeconds(SFXSource.clip.length);
        Destroy(gameObject);
    }
}



    

    

    
