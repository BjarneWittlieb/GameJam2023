using Enemy;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float speedMod = 1f;
    public float aggroRadius = 5f; // primaraly for meele enemies, if set to 0 enemy is always aggro

    private NavMeshAgent _agent;
    private Enemy.Enemy _enemy;

    private Rigidbody2D _enemyRigid;
    private bool hasAggro;


    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Player");

        _enemy = GetComponent<Enemy.Enemy>();
        _agent = GetComponent<NavMeshAgent>();
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }


    // Update is called once per frame  
    private void Update()
    {
        if (_enemy.isDead) return;
        _enemy.stunTimer -= Time.deltaTime;

        _agent.SetDestination(player.transform.position);
        if (_enemy.stunTimer <= 0 && (_agent.remainingDistance < aggroRadius || aggroRadius == 0f || hasAggro))
        {
            _agent.enabled = true;
            hasAggro = true;
            var desiredVelocity = _agent.desiredVelocity;
            _agent.velocity = new Vector3(desiredVelocity.x, desiredVelocity.y / 2, desiredVelocity.z);
        }
        else
        {
            _agent.velocity = new Vector3(0, 0, 0);
        }
    }
}