using UnityEngine;
using UnityEngine.AI;
using NavGame.Core;
 
namespace NavGame.Animation
{
    [RequireComponent(typeof(AttackGameOBJ))]
    public class AttackAnimationController : BasicAnimationController
    {
        protected AttackGameOBJ attackGameObject;
 
        protected override void Awake()
        {
            base.Awake();
            attackGameObject = GetComponent<AttackGameOBJ>();
        }
 
        protected override void Update()
        {
            base.Update();
            animator.SetBool("inCombat", attackGameObject.IsInCombat);
        }
 
        void OnEnable()
        {
            attackGameObject.onAttackStart += OnAttackStart;
        }
 
        void OnAttackStart()
        {
            animator.SetTrigger("attack");
        }
    }
}
