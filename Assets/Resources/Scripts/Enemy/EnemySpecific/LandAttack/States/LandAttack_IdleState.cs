using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_IdleState : EnemyState
{
    private LandAttackEnemy landAttackEnemy;
    private D_E_IdleState stateData;

    private float idleTime;
    private bool isPlayerDetected;  //플레이어가 영역안에 들어왔는지

    public LandAttack_IdleState(LandAttackEnemy landAttackEnemy, EnemyStateMachine stateMachine, string animBoolName, D_E_IdleState stateData) : base(landAttackEnemy, stateMachine, animBoolName)
    {
        this.landAttackEnemy = landAttackEnemy;
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        landAttackEnemy.Movement.SetVelocityZero();
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

        isPlayerDetected = landAttackEnemy.CollisionSense.PlayerDetected;
        landAttackEnemy.Movement.SetVelocityZero();

        if (Time.time >= startTime + idleTime)
        {
            stateMachine.ChangeState(landAttackEnemy.MoveState); //설정된 IdleTime이 지나면 MoveState로 변경
        }
        else if (isPlayerDetected)
        {
            stateMachine.ChangeState(landAttackEnemy.PlayerLookForState);
        }
    }
    //얼마나 IdleState에 머무를지 결정
    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
