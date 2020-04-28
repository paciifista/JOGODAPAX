using UnityEngine;
namespace NavGame.misskiss
{
    public class Spinner : MonoBehaviour
    {
      public Vector3 eulersPerSecond;
      void Update()
      {
          transform.Rotate(eulersPerSecond*Time.deltaTime);
      }
    }
}