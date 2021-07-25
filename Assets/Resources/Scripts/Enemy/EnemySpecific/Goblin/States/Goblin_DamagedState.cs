using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_DamagedState : EnemyDamagedState
{
    Goblin goblin;

    private bool isTouchingWallFront;
    private bool isCliffing;
    private bool isPlayerInAttackArea;

    public Goblin_DamagedState(Goblin goblin, EnemyStateMachine stateMachine, string animBoolName, D_E_DamagedState stateData) : base(goblin, stateMachine, animBoolName, stateData)
    {
        this.goblin = goblin;
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

        isTouchingWallFront = goblin.CollisionSense.WallFront;
        isCliffing = goblin.CollisionSense.Cliffing;
        isPlayerInAttackArea = goblin.CollisionSense.PlayerInAttackArea;

        if (isStunTimeOver)
        {
            if(isTouchingWallFront || isCliffing || isPlayerInAttackArea)
                stateMachine.ChangeState(goblin.PlayerLookForState);
            else
                stateMachine.ChangeState(goblin.PlayerFollowState);
        }
    }
}
