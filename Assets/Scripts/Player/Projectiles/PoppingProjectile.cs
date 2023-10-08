using UnityEngine;

namespace Player.Projectiles
{
    public class PoppingProjectile : Projectile
    {
        private                 Animator animator;
        private                 bool     pop;
        private static readonly int      Pop = Animator.StringToHash("pop");

        protected override void Start()
        {
            base.Start();
            animator = GetComponentInChildren<Animator>();
        }

        protected override void FixedUpdate()
        {
            if (pop)
                return;
            
            base.FixedUpdate();
        }

        protected override void OnCollisionEnter2D(Collision2D other)
        {
            if (pop)
                return;
            
            base.OnCollisionEnter2D(other);
        }

        protected override void DestroyInternal()
        {
            pop = true;
            animator.SetBool(Pop, pop);
            var stateInfo     = animator.GetCurrentAnimatorStateInfo(0);
            var remainingTime = stateInfo.length - stateInfo.normalizedTime * stateInfo.length;
            Destroy(gameObject, remainingTime);
        }
    }
}