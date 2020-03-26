using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavGame.misskiss;
using UnityEngine.AI;

namespace NavGame.Core
{

    public class AttackGameOBJ : TouchableGameOBJ
    {
        public OffenceStats offenceStats;

        protected NavMeshAgent agent;
        float cooldown = 0f;
        float lastAttackTime;
        
        public OnAttackHitEvent onAttackHit;

        protected virtual void Awake()
        {
                    agent = GetComponent<NavMeshAgent>();

        }

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