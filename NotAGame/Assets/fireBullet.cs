using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireInterval = 5f;
    public float bulletForce = 10f;
    public int lifetime = 2;

    private void Start()
    {
        InvokeRepeating(nameof(FireBullet), 0f, fireInterval);
        Destroy(gameObject, lifetime); //  Destroy cannon after lifetime seconds
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.right * bulletForce;
        }
    }
}




    

   
