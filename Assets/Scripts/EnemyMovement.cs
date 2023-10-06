using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D enemyRigid;
    public Rigidbody2D playerRigid;
    public float speedMod = 1f;


    // Start is called before the first frame update
    void Start()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var xDif = playerRigid.position.x - enemyRigid.position.x;
        var yDif = playerRigid.position.y - enemyRigid.position.y;

        var velocity = new Vector2(xDif, yDif).normalized;

        // Stauch it baby, isometric shit
        velocity = new Vector2(velocity.x, velocity.y / 2);

        enemyRigid.velocity = velocity * speedMod;
    }
}
