﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavGame.misskiss;

namespace NavGame.Core
{

    public class ComabatGameOBJ : DamageAbleGameOBJ
    {
        float cooldown = 0f;
        float lastAttackTime;
        protected virtual void Update ()
        {
            DecreaseAttackcooldown();
        }

        public void AttackOnCooldown(DamageAbleGameOBJ target)
        {
            if (cooldown <= 0f)
            {
                cooldown = 1f / stats.attackSpeed;
                target.TakeDamage(stats.damage);
                AudioManager.instance.Play("enemy-hit", target.transform.position);
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

