using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavGame.misskiss;

namespace NavGame.Core
{

    public class ComabatGameOBJ : DamageAbleGameOBJ
    {
        public OffenceStats offenceStats;
        float cooldown = 0f;
        float lastAttackTime;
        
        public OnAttackHitEvent onAttackHit;
        protected virtual void Update ()
        {
            DecreaseAttackcooldown();
        }

        public void AttackOnCooldown(DamageAbleGameOBJ target)
        {
            if (cooldown <= 0f)
            {
                cooldown = 1f / offenceStats.attackSpeed;
                target.TakeDamage(offenceStats.damage);
                if (onAttackHit != null)
                {
                    onAttackHit(target.transform.position);
                }
            }
        }
        void DecreaseAttackcooldown()
        {
            if (cooldown == 0f)
            {
                return;
            }
            cooldown -= Time.deltaTime;
            if (cooldown < 0f)
            {
                cooldown = 0f;
            }
        } 
    }
    
}

