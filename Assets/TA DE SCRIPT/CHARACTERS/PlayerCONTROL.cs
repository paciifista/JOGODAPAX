using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavGame.Core;
[RequireComponent(typeof(NavMeshAgent))]

public class PlayerCONTROL : TouchableGameOBJ
{
    NavMeshAgent agent;
    public LayerMask WalkAble;
    Camera cam;

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
