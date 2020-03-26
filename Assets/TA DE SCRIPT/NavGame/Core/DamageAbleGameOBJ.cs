using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavGame.Core
{
    public class DamageAbleGameOBJ : TouchableGameOBJ
    {
        
        public int currentHealth;
        public DefenceStats defenceStats;
        public OnHealthChangeEvent onHealthChanged;
        public OnDiedEvent onDied;
        protected virtual void Awake ()
        {
            currentHealth = defenceStats.maxHealth;
        }
        public void TakeDamage(int amount)
        {
            amount = amount - defenceStats.armor;
            amount = Mathf.Clamp(amount, 1, defenceStats.maxHealth);

            currentHealth -= amount;

            if (onHealthChanged != null)
            {
                onHealthChanged(defenceStats.maxHealth, currentHealth);
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