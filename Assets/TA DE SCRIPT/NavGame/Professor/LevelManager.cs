using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NavGame.misskiss
{
    public abstract class LevelManager : MonoBehaviour
    {
        public Action[] actions;

        void Start()
        {
            StartCoroutine(SpawnBad());
        } 
        protected abstract IEnumerator SpawnBad();

        [Serializable]
        public class Action
        {
            public int cost;
            public GameObject prefap;
            public float waitTime = 1f;
            public float coolDown;
        }       
    }
}