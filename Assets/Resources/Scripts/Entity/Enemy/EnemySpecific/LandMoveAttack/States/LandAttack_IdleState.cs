using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_IdleState : EnemyState
{
    private LandMoveAttackEnemy landMoveAttackEnemy;
    private D_E_IdleState stateData;

    private float idleTime;
    private bool isPlayerDetected;  //플레이어가 영역안에 들어왔는지

    public LandAttack_IdleState(LandMoveAttackEnemy landMoveAttackEnemy, EnemyStateMachine stateMachine, string animBoolName, D_E_IdleState stateData) : base(landMoveAttackEnemy, stateMachine, animBoolName)
    {
        this.landMoveAttackEnemy = landMoveAttackEnemy;
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        landMoveAttackEnemy.Core.Movement.SetVelocityZero();
        isPlayerDetected = false;
        SetRandomIdleTime();
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        isPlayerDetected = landMoveAttackEnemy.Core.CollisionSense.PlayerDetected;
        landMoveAttackEnemy.Core.Movement.SetVelocityZero();

        if (Time.time >= startTime + idleTime)
        {
            stateMachine.ChangeState(landMoveAttackEnemy.MoveState); //설정된 IdleTime이 지나면 MoveState로 변경
        }
        else if (isPlayerDetected)
        {
            stateMachine.ChangeState(landMoveAttackEnemy.PlayerLookForState);
        }
    }
    //얼마나 IdleState에 머무를지 결정
    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
