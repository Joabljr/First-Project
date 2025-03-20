using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 2f; 
    public GameObject smallerAsteroidPrefab; 
    public int numberOfSmallerAsteroids = 2;
    public int asteroidSize = 3; 
    private bool isTimerActive = false;
    void Start()
    {
       
        AssignRandomDirection();
    }

    void Update()
    {
        
        WrapAroundScreen();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); 

            if (asteroidSize > 1 && smallerAsteroidPrefab != null)
            {
                 SpawnSmallerAsteroids();
            }
            else
            {
                RespawnAsteroid();
            }
        }
    }

    void SpawnSmallerAsteroids()
    {
        for (int i = 0; i < numberOfSmallerAsteroids; i++)
        {
            // Instantiate smaller asteroids at the current position
            GameObject smallerAsteroid = Instantiate(smallerAsteroidPrefab, transform.position, Quaternion.identity);
            Debug.Log("Spawned smaller asteroid: " + smallerAsteroid.name);

            // Set size and speed
            Asteroid smallerAsteroidScript = smallerAsteroid.GetComponent<Asteroid>();
            if (smallerAsteroidScript != null)
            {
                smallerAsteroidScript.asteroidSize = asteroidSize - 1; 
                smallerAsteroidScript.speed = speed * 1.2f; 
            }

            // Randomize velocity
            Rigidbody2D rb = smallerAsteroid.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 randomDirection = Random.insideUnitCircle.normalized;
                rb.velocity = randomDirection * Random.Range(1f, speed);
            }
        }

        Destroy(gameObject);
    }

    void RespawnAsteroid()
    {
        // Assign a new random position within screen bounds
        transform.position = new Vector2(Random.Range(-10f, 10f), Random.Range(-6f, 6f));

        // Assign a new random direction
        AssignRandomDirection();

        Debug.Log("Asteroid respawned!");
    }

    void AssignRandomDirection()
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * speed;
        }
        else
        {
            Debug.LogError("Rigidbody2D component is missing on the asteroid!");
        }
    }

    void WrapAroundScreen()
    {
        // Check if the asteroid is out of bounds and wrap it around
        Vector2 position = transform.position;

        if (position.x > 10) position.x = -10; // Right to Left
        if (position.x < -10) position.x = 10; // Left to Right
        if (position.y > 6) position.y = -6;   // Top to Bottom
        if (position.y < -6) position.y = 6;   // Bottom to Top

        transform.position = position;
    }
    IEnumerator TimerCoroutine()
    {
        isTimerActive = true;
        Debug.Log("Timer started! 1 minutes remaining...");

        yield return new WaitForSeconds(60f); 
        Debug.Log("1-minute timer completed!");

        Destroy(gameObject); 
        isTimerActive = false;
    }
}
