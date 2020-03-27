using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavGame.Core
{
    public class TouchableGameOBJ : BasicGameObject
   {
       public float contactRadius =0.5f;
       public bool IsInTouch(TouchableGameOBJ other)
       {
           float distance = Vector3.Distance(transform.position, other.transform.position);
           return distance < contactRadius + other.contactRadius;
       }



       protected virtual void OnDrawGizmosSelected()
       {
           Gizmos.color = Color.black;
           Gizmos.DrawWireSphere(transform.position, contactRadius);
       }
    }
}
