using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_IdleState : EnemyState
{
    private Goblin goblin;
    private D_E_IdleState stateData;

    private float idleTime;
    private bool isPlayerDetected;  //�÷��̾ �����ȿ� ���Դ���

    public Goblin_IdleState(Goblin goblin, EnemyStateMachine stateMachine, string animBoolName, D_E_IdleState stateData) : base(goblin, stateMachine, animBoolName)
    {
        this.goblin = goblin;
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        goblin.Movement.SetVelocityZero();
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
        isPlayerDetected = goblin.CollisionSense.PlayerDetected;
        goblin.Movement.SetVelocityZero();
        if (Time.time >= startTime + idleTime)
        {
            stateMachine.ChangeState(goblin.MoveState); //������ IdleTime�� ������ MoveState�� ����
        }
        else if (isPlayerDetected)
        {
            stateMachine.ChangeState(goblin.PlayerLookForState);
        }

        
    }
    //�󸶳� IdleState�� �ӹ����� ����
    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
