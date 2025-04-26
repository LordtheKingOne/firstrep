using UnityEngine;

public class PeriodicZRotation : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float unstableDuration;
    public float interval;

    private void Start()
    {
        unstableDuration = 3f;
        interval = 20f;

        if (rb == null) rb = GetComponent<Rigidbody2D>();
        StartCoroutine(RotationCycle());
    }


    private System.Collections.IEnumerator RotationCycle()
    {
        while (true)
        {
            // Wait until next cycle
            yield return new WaitForSeconds(interval);

            // Allow Z rotation

            rb.freezeRotation = false;

            // Stay unstable for duration
            yield return new WaitForSeconds(unstableDuration);

            // Freeze Z rotation again and stand upright
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            rb.freezeRotation = true;
            
        }
    }
}


