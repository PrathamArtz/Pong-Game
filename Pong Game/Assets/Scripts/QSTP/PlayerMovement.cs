using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (gameObject.name == "Player 1")
        {
            float verticalInput1 = Input.GetAxis("Vertical1");
            //transform.position += new Vector3(0,speed*verticalInput1, 0);
            _rb.velocity = new Vector2(0, speed * verticalInput1);

        }
        else if (gameObject.name == "Player 2")
        {
            float verticalInput2 = Input.GetAxis("Vertical2");
            //transform.position += new Vector3(0, speed*verticalInput2, 0);
            _rb.velocity = new Vector2(0, speed * verticalInput2);
        }
    }
}
