using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigid;
    private Quaternion initialRotation;

    // public Variablen sieht man im Inspector-Fenster von Unity und kann sie dort modifizieren
    // der zugewiesene Wert ist ein Default
    public float speedMod = 1.0f;

    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        initialRotation = transform.rotation;
    }

    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        Vector2 velocity = new Vector2(horizontalInput, verticalInput).normalized * Math.Max(Math.Abs(horizontalInput), Math.Abs(verticalInput));

        // Stauch it baby, isometric shit
        velocity = new Vector2(velocity.x, velocity.y / 2);

        playerRigid.velocity = speedMod * velocity;
    }

    void LateUpdate()
    {
        transform.rotation = initialRotation;
    }
}