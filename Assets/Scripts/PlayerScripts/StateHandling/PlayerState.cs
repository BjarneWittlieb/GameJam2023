using UnityEngine;

namespace PlayerScripts.StateHandling
{
    public abstract class PlayerState
    {
        private readonly int      animHash;
        private          Animator animator;

        protected PlayerState(Player player, PlayerStateMachine playerStateMachine)
        {
            Player             = player;
            PlayerStateMachine = playerStateMachine;
            animHash           = Animator.StringToHash(AnimName);
        }

        protected       Player             Player             { get; }
        protected       PlayerStateMachine PlayerStateMachine { get; }
        public abstract State           Key                { get; }
        public abstract string             AnimName           { get; }

        public virtual void Enter()
        {
            animator.SetBool(animHash, true);
        }

        public virtual void Update() { }

        public virtual void Exit()
        {
            animator.SetBool(animHash, false);
        }
    }
}