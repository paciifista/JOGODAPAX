using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavGame.Core
{
    public class DamageAbleGameOBJ : TouchableGameOBJ
    {
        
        public int currentHealth;
        public Stats stats;
        protected virtual void Awake ()
        {
            currentHealth = stats.maxHealth;
        }
        public void TakeDamage(int amount)
        {
            amount = amount - stats.armor;
            amount = Mathf.Clamp(amount, 1, stats.maxHealth);

            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            Destroy(gameObject);
        }

    }
}