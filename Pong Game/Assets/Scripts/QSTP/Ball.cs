using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D _rb;
    public float speed = 5;
    Vector3 ogPosition;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        ogPosition = transform.position;
        ResetBall();
    }

    private void Update()
    {
        
    }

    void ResetBall()
    {
        transform.position = ogPosition;

        float randomX = Random.Range(-1, 1);
        float randomY = Random.Range(-1, 1);

        Vector2 throwDirection = new Vector2( speed * randomX, speed * randomY).normalized;
        _rb.velocity = speed * throwDirection;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.name == "Left Wall" || other.collider.name == "Right Wall")
        {
            ResetBall();
        }
    }
}
