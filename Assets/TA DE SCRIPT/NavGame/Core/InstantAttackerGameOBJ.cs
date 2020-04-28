using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavGame.Core
{
    public class InstantAttackerGameOBJ : AttackGameOBJ
    {
        protected override void Attack(DamageAbleGameOBJ target)
        {
            target.TakeDamage(offenceStats.damage);
            if (onAttackStrike != null)
            {
                onAttackStrike(target.damageTransform.position);
            }
        }
    }
}