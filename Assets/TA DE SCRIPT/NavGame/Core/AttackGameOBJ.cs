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

        public string[] enemyLayer;

        [SerializeField]
        protected List<DamageAbleGameOBJ> enemiesToAttack = new List<DamageAbleGameOBJ>();

        protected NavMeshAgent agent;
        float cooldown = 0f;
        LayerMask enemyMask;
        float lastAttackTime;

        public OnAttackHitEvent onAttackHit;

        protected virtual void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            enemyMask = LayerMask.GetMask(enemyLayer);
        }

        protected virtual void Update()
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

        void OnTriggerEnter(Collider other)
        {
            if (enemyMask.Contains(other.gameObject.layer))
            {
                DamageAbleGameOBJ obj = other.transform.parent.GetComponent<DamageAbleGameOBJ>();
                if (!enemiesToAttack.Contains(obj))
                {
                    enemiesToAttack.Add(obj);
                    obj.onDied += () => { enemiesToAttack.Remove(obj); };
                }
            }
        }


        void OnTriggerExit(Collider other)
        {
            if (enemyMask.Contains(other.gameObject.layer))
            {
                DamageAbleGameOBJ obj = other.transform.parent.GetComponent<DamageAbleGameOBJ>();
                enemiesToAttack.Remove(obj);
            }
        }


    }

}