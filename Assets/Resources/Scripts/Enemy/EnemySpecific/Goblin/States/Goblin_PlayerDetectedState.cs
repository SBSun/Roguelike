using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_PlayerDetectedState : EnemyState
{
    private Goblin goblin;

    private bool isPlayerDetected;
    private bool isPlayerInAttackArea;

    public Goblin_PlayerDetectedState(Goblin goblin, EnemyStateMachine stateMachine, string animBoolName) : base(goblin, stateMachine, animBoolName)
    {
        this.goblin = goblin;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        isPlayerDetected = goblin.CollisionSense.PlayerDetected;
        isPlayerInAttackArea = goblin.CollisionSense.PlayerInAttackArea;

        if (isPlayerDetected)
        {
            if(isPlayerInAttackArea && goblin.AttackState.CheckAttackCoolTime())
            {
                stateMachine.ChangeState(goblin.AttackState);
            }
            else
            {
                stateMachine.ChangeState(goblin.PlayerFollowState);
            }
        }
        else
        {
            stateMachine.ChangeState(goblin.IdleState);
        }
    }
}
