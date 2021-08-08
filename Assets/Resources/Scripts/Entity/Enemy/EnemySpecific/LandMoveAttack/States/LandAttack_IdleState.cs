using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack_IdleState : EnemyState
{
    private LandMoveAttackEnemy landMoveAttackEnemy;
    private D_E_IdleState stateData;

    private float idleTime;
    private bool isPlayerDetected;  //�÷��̾ �����ȿ� ���Դ���

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
            stateMachine.ChangeState(landMoveAttackEnemy.MoveState); //������ IdleTime�� ������ MoveState�� ����
        }
        else if (isPlayerDetected)
        {
            stateMachine.ChangeState(landMoveAttackEnemy.PlayerLookForState);
        }
    }
    //�󸶳� IdleState�� �ӹ����� ����
    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
