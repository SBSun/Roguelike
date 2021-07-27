using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_IdleState : EnemyState
{
    private Skeleton skeleton;
    private D_E_IdleState stateData;

    private float idleTime;

    private bool isPlayerDetected;

    public Skeleton_IdleState(Skeleton skeleton, EnemyStateMachine stateMachine, string animBoolName, D_E_IdleState stateData) : base(skeleton, stateMachine, animBoolName)
    {
        this.skeleton = skeleton;
        this.stateData = stateData;
    }
    public override void Enter()
    {
        base.Enter();

        skeleton.Movement.SetVelocityZero();
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

        isPlayerDetected = skeleton.CollisionSense.PlayerDetected;
        skeleton.Movement.SetVelocityZero();

        if (Time.time >= startTime + idleTime)
        {
            stateMachine.ChangeState(skeleton.MoveState); //설정된 IdleTime이 지나면 MoveState로 변경
        }
        else if (isPlayerDetected)
        {
            stateMachine.ChangeState(skeleton.PlayerLookForState);
        }
    }
    //얼마나 IdleState에 머무를지 결정
    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
