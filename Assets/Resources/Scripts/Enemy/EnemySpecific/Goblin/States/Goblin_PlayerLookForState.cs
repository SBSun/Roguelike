using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_PlayerLookForState : Goblin_PlayerDetectedState
{

    public Goblin_PlayerLookForState(Goblin goblin, EnemyStateMachine stateMachine, string animBoolName) : base(goblin, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        goblin.Movement.SetVelocityZero();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (CheckPlayerFollow())
            stateMachine.ChangeState(goblin.PlayerFollowState);
    }
}
