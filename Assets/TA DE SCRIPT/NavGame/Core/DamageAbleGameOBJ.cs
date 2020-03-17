using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavGame.Core
{
    public class DamageAbleGameOBJ : TouchableGameOBJ
    {
        
        public int currentHealth;
        public Stats stats;
        public OnHealthChangeEvent onHealthChanged;
        public OnDiedEvent onDied;
        protected virtual void Awake ()
        {
            currentHealth = stats.maxHealth;
        }
        public void TakeDamage(int amount)
        {
            amount = amount - stats.armor;
            amount = Mathf.Clamp(amount, 1, stats.maxHealth);

            currentHealth -= amount;

            if (onHealthChanged != null)
            {
                onHealthChanged(stats.maxHealth, currentHealth);
            }

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            Destroy(gameObject);
            if (onDied != null)
            {
                onDied();
            }
        }

    }
}