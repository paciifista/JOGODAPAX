using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavGame.Core;
using NavGame.misskiss;

[RequireComponent(typeof(NavMeshAgent))]

public class PlayerCONTROL : TouchableGameOBJ
{
    NavMeshAgent agent;
    public LayerMask WalkAble;
    public LayerMask collectibleLayer;
    Camera cam;
    public float range = 4f;

    CollectibleGameOBJ pickupTarget;
    Vector3 actionPoint = Vector3.zero;
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
        UpdateAction();
    }
    void ProcessInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            LevelManager.instance.CancelAction();
            actionPoint = Vector3.zero;
            
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
        else if (Input.GetMouseButtonDown(0) && LevelManager.instance.IsActionSelected())
        {
            
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, WalkAble))
            {
                actionPoint = hit.point;
                agent.SetDestination(hit.point);
            }


        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LevelManager.instance.SelectAction(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LevelManager.instance.SelectAction(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LevelManager.instance.SelectAction(2);
        }
    }

    void UpdateCollect()
    {
        if (pickupTarget != null)
        {
            if (IsInTouch(pickupTarget))
            {
                pickupTarget.Pickup();
                LevelManager.instance.AddResource(pickupTarget.amount);
            }
        }
    }

    void UpdateAction()
    {
        if (actionPoint != Vector3.zero)
        {
            if(Vector3.Distance(transform.position, actionPoint) <= range)
            {
                agent.ResetPath();
                LevelManager.instance.DoAction(actionPoint);
                actionPoint = Vector3.zero;
            }
        }
    }
}
