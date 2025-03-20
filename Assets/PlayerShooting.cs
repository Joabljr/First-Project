using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign your bullet prefab in the Inspector
    public Transform firePoint;    // Set the position where bullets are spawned
    public float bulletSpeed = 10f; // Speed of the bullets
    public float rotationSpeed = 100f;

    


    void Update()
    {
        // Check for shooting input (Space key)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
    transform.Rotate(Vector3.forward * -rotation);
    }

void Shoot()
{
    // Instantiate the bullet at the firePoint's position and rotation
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    // Apply force to the bullet
    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    if (rb != null)
    {
        rb.velocity = firePoint.up * bulletSpeed; // Fire bullet in the firePoint's direction
    }

    Destroy(bullet, 2f); // Destroy bullet after 2 seconds
}



}
