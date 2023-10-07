using PlayerScripts.StateHandling;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int                maxHp;
        private                  int                hp;
        public                   Animator           Animator     { get; private set; }
        public                   PlayerStateMachine StateMachine { get; private set; }

        private void Awake()
        {
            StateMachine = new PlayerStateMachine(this);
        }

        // Start is called before the first frame update
        private void Start()
        {
            hp       = maxHp;
            Animator = GetComponentInChildren<Animator>();
            StateMachine.Initialize(State.Idle);
        }

        // Update is called once per frame
        private void Update()
        {
            StateMachine.CurrentState.Update();
        }

        public void TakeDamage(int damage)
        {
            hp -= damage;

            if (hp <= 0)
                Debug.Log("Game OVER!");
        }
    }
}