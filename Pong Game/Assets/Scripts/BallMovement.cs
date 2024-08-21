using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    public float speed = 5;
    Vector3 ogPosition;
    public Text playerScore, computerScore;
    private int ps, cs;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        ogPosition = transform.position;
        ResetBall();
    }


    void Update()
    {

    }

    void ResetBall()
    {
        transform.position = ogPosition;

        float randomX = Random.Range(-1, 1);
        float randomY = Random.Range(-1, 1);

        while (randomX == 0) randomX = Random.Range(-1f, 1f);
        while (randomY == 0) randomY = Random.Range(-1f, 1f);

        Vector2 throwDirection = new Vector2(speed * randomX, speed * randomY).normalized;
        _rb.velocity = speed * throwDirection;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Left Wall" || other.collider.name == "Right Wall")
        {
            if (other.collider.name == "Right Wall")
            {
                ps++;
                playerScore.text = ps.ToString();
            }

            if (other.collider.name == "Left Wall")
            {
                cs++;
                computerScore.text = cs.ToString();
            }

            ResetBall();
        }
    }
}
