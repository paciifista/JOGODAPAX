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

        public float attackRange = 4f;
        public float attackDelay = 0.5f;
        public Transform castTransform;
        public string[] enemyLayer;

        [SerializeField]
        protected List<DamageAbleGameOBJ> enemiesToAttack = new List<DamageAbleGameOBJ>();

        protected NavMeshAgent agent;
        float cooldown = 0f;
        LayerMask enemyMask;
        public OnAttackCastEvent onAttackCast;
        public OnAttackStartEvent onAttackStart;
        float lastAttackTime;

        public OnAttackStrikeEvent onAttackStrike;

        protected virtual void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            enemyMask = LayerMask.GetMask(enemyLayer);

            if (castTransform == null)
            {
                castTransform = transform;
            }
        }

        protected virtual void Update()
        {
            DecreaseAttackcooldown();
            UpdateAttack();
        }

        protected virtual void UpdateAttack()
        {
            if (enemiesToAttack.Count > 0)
            {
                agent.SetDestination(enemiesToAttack[0].gameObject.transform.position);
                if (IsInRange(enemiesToAttack[0].gameObject.transform.position))
                {
                    agent.ResetPath();
                    FaceObjectFrame(enemiesToAttack[0].gameObject.transform);
                    AttackOnCooldown(enemiesToAttack[0]);
                }
            }

        }

        public void AttackOnCooldown(DamageAbleGameOBJ target)
        {
            if (cooldown <= 0f)
            {
                cooldown = 1f / offenceStats.attackSpeed;
                if (onAttackStart != null)
                {
                    onAttackStart();
                }
                StartCoroutine(AttackAfterDelay(target, attackDelay));
            }
        }

        IEnumerator AttackAfterDelay(DamageAbleGameOBJ target, float delay)
        {
            yield return new WaitForSeconds(delay);
            if (target != null)
            {
                if (onAttackCast != null)
                {
                    onAttackCast(castTransform.position);
                }

                target.TakeDamage(offenceStats.damage);
                if (onAttackStrike != null)
                {
                    onAttackStrike(target.damageTransform.position);
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

        public bool IsInRange(Vector3 point)
        {
            float distance = Vector3.Distance(transform.position, point);
            return distance <= attackRange;
        }


        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }

}