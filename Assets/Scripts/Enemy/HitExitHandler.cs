using UnityEngine;

namespace Enemy
{
    public class HitExitHandler : MonoBehaviour {
    private                 Animator anim;
    private static readonly int      IsHit = Animator.StringToHash("isHit");

    private void Start() {
        anim = GetComponent<Animator>();
    }

    public void ResetParamAfterAnimation() {
        anim.SetBool(IsHit, false);
    }
    }
    
}