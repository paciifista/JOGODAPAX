using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class PlayerCONTROL : MonoBehaviour
{
    NavMeshAgent agent;
    public LayerMask WalkAble;
    Camera cam;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(1))
       {
           Ray ray = cam.ScreenPointToRay(Input.mousePosition);
           RaycastHit hit;

           if (Physics.Raycast(ray, out hit, Mathf.Infinity, WalkAble))
           {
             agent.SetDestination(hit.point);  
           }
       }
    }
}
