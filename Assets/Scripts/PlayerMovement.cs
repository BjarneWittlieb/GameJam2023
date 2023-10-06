using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigit;

    public float speedMod = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigit = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        Vector2 velocity = new Vector2(horizontalInput, verticalInput).normalized * Math.Max(Math.Abs(horizontalInput), Math.Abs(verticalInput));

        // Stauch it baby, isometric shit
        velocity = new Vector2(velocity.x, velocity.y / 2);

        playerRigit.velocity = speedMod * velocity;
    }       
}
