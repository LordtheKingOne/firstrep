using UnityEngine;

public class rotate : MonoBehaviour
{
    public float rotationSpeed = 90f; // degrees per second

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    
}
