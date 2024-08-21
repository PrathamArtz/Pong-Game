using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : Paddle
{
    public Rigidbody2D ball;

    private void FixedUpdate()
    {
        if (ball.velocity.x > 0f)
        {
            // Move the paddle in the direction of the ball to track it
            if (ball.position.y > _rb.position.y)
            {
                _rb.AddForce(Vector2.up * speed);
            }
            else if (ball.position.y < _rb.position.y)
            {
                _rb.AddForce(Vector2.down * speed);
            }
        }
        else
        {
            // Move towards the center of the field and idle there until the
            // ball starts coming towards the paddle again
            if (_rb.position.y > 0f)
            {
                _rb.AddForce(Vector2.down * speed);
            }
            else if (_rb.position.y < 0f)
            {
                _rb.AddForce(Vector2.up * speed);
            }
        }
    }
}
