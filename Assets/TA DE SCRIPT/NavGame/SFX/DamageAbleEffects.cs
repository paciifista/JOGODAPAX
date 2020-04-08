using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavGame.Core;


namespace NavGame.Effects
{
    [RequireComponent (typeof(DamageAbleGameOBJ))]
    public class DamageAbleEffects : SFXController
    {
        public string damageSound;
        public string dieSound;
        public GameObject damageEffects;
        public GameObject dieEffect;
        void Awake()
        {
            DamageAbleGameOBJ damageAble = GetComponent<DamageAbleGameOBJ>();
            damageAble.onDamageTaken += OnDamageTaken;
            damageAble.onDied += OnDied;
        }

        protected virtual void OnDamageTaken(Vector3 strikePoint, int amount)
        {
            PlayEffects (strikePoint, damageSound, damageEffects, Quaternion.identity);
        }

        protected virtual void OnDied()
        {
            PlayEffects (transform.position, dieSound, dieEffect, Quaternion.identity);
        }


    }

}