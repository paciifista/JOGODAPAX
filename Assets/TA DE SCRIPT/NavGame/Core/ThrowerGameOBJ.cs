using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavGame.Core
{

    public class ThrowerGameOBJ : AttackGameOBJ
    {

        public GameObject projectilePrefab;
        protected override void Attack(DamageAbleGameOBJ target)
        {
            
            GameObject projectile = Instantiate(projectilePrefab, castTransform.position, Quaternion.identity) as GameObject;
            ProjectileController controller = projectile.GetComponent<ProjectileController>();
            controller.Init(target, offenceStats.damage);
            controller.onAttackStrike += onAttackStrike;

        }

        void OnAttackStrike(Vector3 strikePoint)
        {
            if (onAttackStrike != null)
            {
                onAttackStrike(strikePoint);
            }
        }
    }
}