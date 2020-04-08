using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavGame.misskiss

{
    public class DestroyWithDelay : MonoBehaviour
    {
        public float delay = 2;
        void Start()
        {
            Destroy(gameObject, delay);
        }

        void Update()
        {

        }
    }
}