using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavGame.Core;
using NavGame.misskiss;

[RequireComponent(typeof(NavMeshAgent))]
public class CreepController : ComabatGameOBJ
{
    NavMeshAgent agent;
    DamageAbleGameOBJ finalTarget;
    protected override void Awake()
    {
        base.Awake ();
        agent = GetComponent<NavMeshAgent>();
        GameObject obj = GameObject.FindWithTag("Finish");
        if (obj != null)
        {
            finalTarget = obj.GetComponent<DamageAbleGameOBJ>();
        }

        onAttackHit += PlayEffects;  
    }

    protected override void Update()
    {
        base.Update();
        if (finalTarget == null)
        {
            return;
        }
        if (IsInTouch(finalTarget))
        {
            AttackOnCooldown(finalTarget);
        }
    }

    // Update is called once per frame
    void Start()
    {
        if (finalTarget != null)
        {
            agent.SetDestination(finalTarget.transform.position);
        }
    }

    void PlayEffects(Vector3 position)
    {
        AudioManager.instance.Play("enemy-hit",position);
    }
}
