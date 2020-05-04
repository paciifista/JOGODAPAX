using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NavGame.misskiss
{
    public abstract class LevelManager : MonoBehaviour
    {
        public static LevelManager instance;

        public Action[] actions;
        protected int selectedAction = -1;
        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            StartCoroutine(SpawnBad());
        }
        public virtual void SelectAction(int actionIndex)
        {
            Debug.Log("Selected " + actions[actionIndex].prefap.name);
            selectedAction = actionIndex;
        }
        public virtual void DoAction(Vector3 point)
        {
            Debug.Log("DO: " +  actions[selectedAction].prefap.name);
            Instantiate(actions[selectedAction].prefap, point, Quaternion.identity);
        }
        public virtual void CancelAction()
        {
            if(selectedAction != -1)
            {
                selectedAction = -1;
            }
        }
        public bool IsActionSelected()
        {
            return selectedAction != -1;
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