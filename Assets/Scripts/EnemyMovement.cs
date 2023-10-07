using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float speedMod = 1f;
    private NavMeshAgent _agent;

    private Rigidbody2D _enemyRigid;


    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Player");

        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }


    // Update is called once per frame  
    private void Update()
    {
        _agent.SetDestination(player.transform.position);
        var desiredVelocity = _agent.desiredVelocity;
        _agent.velocity = new Vector3(desiredVelocity.x, desiredVelocity.y / 2, desiredVelocity.z);
    }
}