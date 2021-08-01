using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_DeathState : EnemyState
{
    private D_E_DeathState stateData;

    private LandAttackEnemy landAttackEnemy;

    public LandAttack_DeathState(LandAttackEnemy landAttackEnemy, EnemyStateMachine stateMachine, string animBoolName, D_E_DeathState stateData) : base(landAttackEnemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
        this.landAttackEnemy = landAttackEnemy;
    }

    public override void Enter()
    {
        base.Enter();

        GameObject.Instantiate(stateData.deathParticle, landAttackEnemy.transform.position, stateData.deathParticle.transform.rotation);
        GameObject.Instantiate(stateData.bloodSplash, (Vector2)landAttackEnemy.Collider.bounds.center - new Vector2(0, landAttackEnemy.Collider.bounds.extents.y), stateData.bloodSplash.transform.rotation);
        GameObject.Destroy(landAttackEnemy.gameObject);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
}
