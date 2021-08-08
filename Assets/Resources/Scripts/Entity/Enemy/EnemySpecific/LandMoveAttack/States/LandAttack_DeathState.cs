using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_DeathState : EnemyState
{
    private D_E_DeathState stateData;

    private LandMoveAttackEnemy landMoveAttackEnemy;

    public LandAttack_DeathState(LandMoveAttackEnemy landMoveAttackEnemy, EnemyStateMachine stateMachine, string animBoolName, D_E_DeathState stateData) : base(landMoveAttackEnemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
        this.landMoveAttackEnemy = landMoveAttackEnemy;
    }

    public override void Enter()
    {
        base.Enter();

        GameObject.Instantiate(stateData.deathParticle, landMoveAttackEnemy.transform.position, stateData.deathParticle.transform.rotation);
        GameObject.Instantiate(stateData.bloodSplash, (Vector2)landMoveAttackEnemy.Collider.bounds.center - new Vector2(0, landMoveAttackEnemy.Collider.bounds.extents.y), stateData.bloodSplash.transform.rotation);
        GameObject.Destroy(landMoveAttackEnemy.gameObject);
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
