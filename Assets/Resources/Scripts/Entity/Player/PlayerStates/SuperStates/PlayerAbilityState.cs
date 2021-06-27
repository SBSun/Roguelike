using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool isAbilityDone;

    private bool isGrounded;
    public PlayerAbilityState(Player player, PlayerStateMachine stateMachine, SO_PlayerData SO_PlayerData, string animBoolName) : base(player, stateMachine, SO_PlayerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = core.CollisionSense.Grounded;
    }

    public override void Enter()
    {
        base.Enter();

        isAbilityDone = false; ;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //Action�� ������
        if(isAbilityDone)
        {
            //���� ������ -> IdleState
            if(isGrounded && core.Movement.CurrentVelocity.y < 0.01f)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            //���߿� ������ -> InAirState
            else
            {
                stateMachine.ChangeState(player.InAirState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
