using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static int RATIO_X_VELOCITY_TO_Y_VELOCITY = 2;
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
        playerRigid.velocity = speedMod * computeIsometricVelocity();
    }

    Vector2 computeIsometricVelocity()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var scaleFactor = Math.Max(Math.Abs(x), Math.Abs(y));
        return Vector2.Scale(new Vector2(x, y).normalized,
            new Vector2(scaleFactor, scaleFactor / RATIO_X_VELOCITY_TO_Y_VELOCITY));
    }
}