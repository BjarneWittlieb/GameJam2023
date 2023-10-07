using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static float RATIO_X_VELOCITY_TO_Y_VELOCITY = 3f / 2f;
    private Rigidbody2D playerRigid;
    private Quaternion initialRotation;

    private bool  facingRight = true;
    private  float facingDir   = 1;

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
        playerRigid.velocity = speedMod * ComputeIsometricVelocity();

        FlipController();
    }

    private void FlipController()
    {
        switch (playerRigid.velocity.x)
        {
            case > 0 when !facingRight:
            case < 0 when facingRight: Flip();
                break;
        }
    }

    private void Flip()
    {
        facingDir   *= -1;
        facingRight =  !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private static Vector2 ComputeIsometricVelocity()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var scaleFactor = Math.Max(Math.Abs(x), Math.Abs(y));
        return Vector2.Scale(new Vector2(x, y).normalized,
            new Vector2(scaleFactor, scaleFactor / RATIO_X_VELOCITY_TO_Y_VELOCITY));
    }
}