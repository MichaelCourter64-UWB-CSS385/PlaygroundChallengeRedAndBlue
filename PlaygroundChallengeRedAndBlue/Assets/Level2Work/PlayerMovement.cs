using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed;             // Speed multiplier
    public float maxspeed;          // Maximum allowed speed

    private Rigidbody2D R2D;        // Reference to Rigidbody2D component
    private float moveHorizontal;   // float for reading input for Horizontal Movement
    private float moveVertical;     // float for reading input for Vertical Movement

    void Start()
    {
        R2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (this.gameObject.tag == "Player") {
            // Read inputs
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = 0;
            //float moveVertical = Input.GetAxis("Vertical");

            // Convert inputs to Vector2
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            // Check if player is at max speed, AddForce if not
            if (R2D.velocity.magnitude < maxspeed)
            {
                R2D.AddForce(movement * speed);
            }
        } else if (this.gameObject.tag == "Player2") {
            // Read inputs
            moveHorizontal = Input.GetAxis("Horizontal2");
            moveVertical = 0;

            // Convert inputs to Vector2
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            // Check if player is at max speed, AddForce if not
            if (R2D.velocity.magnitude < maxspeed)
            {
                R2D.AddForce(movement * speed);
            }
        }
    }
}