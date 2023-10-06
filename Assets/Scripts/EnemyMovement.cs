using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D playerRigid;
    public float speedMod = 1f;
    private Rigidbody2D enemyRigid;


    // Start is called before the first frame update
    private void Start()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    private void Update()
    {
        var xDif = playerRigid.position.x - enemyRigid.position.x;
        var yDif = playerRigid.position.y - enemyRigid.position.y;

        var velocity = new Vector2(xDif, yDif).normalized;

        // Stauch it baby, isometric shit
        velocity = new Vector2(velocity.x, velocity.y / 2);

        enemyRigid.velocity = velocity * speedMod;
    }
}