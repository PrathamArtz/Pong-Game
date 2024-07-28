using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    Rigidbody2D _rb;
    public float speed = 5;
    Vector3 ogPosition;
    public Text p1Score, p2Score;
    private int p1, p2;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        ogPosition = transform.position;
        ResetBall();
        p1 = 0;
        p2 = 0;
    }

    private void Update()
    {
        
    }

    void ResetBall()
    {
        transform.position = ogPosition;

        float randomX = Random.Range(-1, 1);
        float randomY = Random.Range(-1, 1);

        while (randomX == 0) randomX = Random.Range(-1f, 1f); 
        while (randomY == 0) randomY = Random.Range(-1f, 1f); 

        Vector2 throwDirection = new Vector2( speed * randomX, speed * randomY).normalized;
        _rb.velocity = speed * throwDirection;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.name == "Left Wall" || other.collider.name == "Right Wall")
        {
            if(other.collider.name == "Right Wall")
            {
                p1++;
                p1Score.text = p1.ToString();
            }

            if (other.collider.name == "Left Wall")
            {
                p2++;
                p2Score.text = p2.ToString();
            }

            ResetBall();
        }
    }
}
