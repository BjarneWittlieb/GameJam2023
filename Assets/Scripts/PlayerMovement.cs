using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static float RATIO_X_VELOCITY_TO_Y_VELOCITY = 3f / 2f;
    private Rigidbody2D playerRigid;
    private Quaternion initialRotation;

    private Animator animator;

    private bool  facingRight = true;
    private  float facingDir   = 1;
    private bool facingFront = true;

    #region Dash

    [Header("Dash info")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;
    private                  float dashCooldownTimer;
    private                  bool  isDashing;

    #endregion

    // public Variablen sieht man im Inspector-Fenster von Unity und kann sie dort modifizieren
    // der zugewiesene Wert ist ein Default
    public                  float speedMod = 1.0f;
    private static readonly int   FacingFrontHash = Animator.StringToHash("facing front");

    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        initialRotation = transform.rotation;

        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        DashController();
        FlipController();

        var speed = isDashing ? dashSpeed : speedMod;
        playerRigid.velocity = speed * ComputeIsometricVelocity();
        animator.SetBool(FacingFrontHash, facingFront);
    }

    private void DashController()
    {
        dashCooldownTimer -= Time.deltaTime;
        isDashing         =  dashCooldownTimer >= dashCooldown - dashDuration;

        if (!Input.GetKeyDown(KeyCode.LeftShift) || dashCooldownTimer > 0)
            return;
        
        dashCooldownTimer = dashCooldown;
    }

    private void FlipController()
    {
        switch (playerRigid.velocity.x)
        {
            case > 0 when !facingRight:
            case < 0 when facingRight: Flip();
                break;
        }
        switch (playerRigid.velocity.y)
        {
            case > .1f when facingFront:
            case < -1f when !facingFront: 
                facingFront = !facingFront;
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