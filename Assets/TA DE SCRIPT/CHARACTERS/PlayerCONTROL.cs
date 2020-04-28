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
    public LayerMask collectibleLayer;
    Camera cam;

    CollectibleGameOBJ pickupTarget;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        UpdateCollect();
    }
    void ProcessInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, WalkAble))
            {
                agent.SetDestination(hit.point);
            }


            if (Physics.Raycast(ray, out hit, Mathf.Infinity, collectibleLayer))
            {
                pickupTarget = hit.collider.gameObject.GetComponent<CollectibleGameOBJ>();
                agent.SetDestination(hit.point);

            }
            else
            {
                pickupTarget = null;
            }
        }
    }

    void UpdateCollect()
    {
        if (pickupTarget != null)
        {
            if (IsInTouch(pickupTarget))
            {
                pickupTarget.Pickup();
            }
        }
    }
}
