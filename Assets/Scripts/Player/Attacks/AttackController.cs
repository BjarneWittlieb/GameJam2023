using UnityEngine;

namespace Player.Attacks
{
    public class AttackController : MonoBehaviour
    {
        [SerializeField] private BubbleAttack        bubbleAttack;
        [SerializeField] private FireballAttack      fireballAttack;
        private                  ProgressionTracking pt;
        
        public int FireBaseDamage   { get; set; } = 10;
        public int BubbleBaseDamage { get; set; } = 10;

        private void Start()
        {
            pt = ProgressionTracking.Instance;
        }

        private void Update()
        {
            if (!Input.GetKey(KeyCode.Mouse0))
                return;

            if (pt.CurrentRoom.IsGood)
                fireballAttack.Fire(GetCurrentBaseDamage());
            else
                bubbleAttack.Fire(GetCurrentBaseDamage());
        }
        
        private int GetCurrentBaseDamage()
        {
            return ProgressionTracking.Instance.CurrentRoom.IsGood ? FireBaseDamage : BubbleBaseDamage;
        }
    }
}