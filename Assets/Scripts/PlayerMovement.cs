using System;
using UnityEngine;

// ReSharper disable All

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigid;
    private Quaternion initialRotation;

    // ReSharper disable once CommentTypo
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
        playerRigid.velocity = speedMod * computeVelocity();
    }

    Vector2 computeVelocity()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var scaleFactor = Math.Max(Math.Abs(x), Math.Abs(y));
        return new Vector2(x * scaleFactor, y * scaleFactor / 2);
    }

    void LateUpdate()
    {
        transform.rotation = initialRotation;
    }
}