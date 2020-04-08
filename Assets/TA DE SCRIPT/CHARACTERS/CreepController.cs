using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavGame.Core;
using NavGame.misskiss;

public class CreepController : AttackGameOBJ
{
    DamageAbleGameOBJ finalTarget;
    protected override void Awake()
    {
        base.Awake();

        agent = GetComponent<NavMeshAgent>();
        GameObject obj = GameObject.FindWithTag("Finish");
        if (obj != null)
        {
            finalTarget = obj.GetComponent<DamageAbleGameOBJ>();
        }
    }

    protected override void Update()
    {
        base.Update();
        if (finalTarget != null && enemiesToAttack.Count == 0)
        {
            agent.SetDestination(finalTarget.transform.position);
            if (IsInTouch(finalTarget))
            {
                agent.ResetPath();
                FaceObjectFrame(finalTarget.gameObject.transform);
                AttackOnCooldown(finalTarget);
            }
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

}
