using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavGame.Core
{


    public class CollectibleGameOBJ : TouchableGameOBJ
    {
        public int amount = 1;

        public virtual void Pickup()
        {
            Destroy(gameObject);
        }
        
    }
}