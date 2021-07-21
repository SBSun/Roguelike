using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_PlayerDetectedState : EnemyState
{
    private Goblin goblin;
    private D_E_MoveState stateData;

    private bool isTouchingWallFront;
    private bool isCliffing;
    private bool isPlayerDetected;
    private bool isPlayerInAttackArea;

    public Goblin_PlayerDetectedState(Goblin goblin, EnemyStateMachine stateMachine, string animBoolName, D_E_MoveState stateData) : base(goblin, stateMachine, animBoolName)
    {
        this.goblin = goblin;
        this.stateData = stateData;
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

        isTouchingWallFront = goblin.CollisionSense.WallFront;
        isCliffing = goblin.CollisionSense.Cliffing;
        isPlayerDetected = goblin.CollisionSense.PlayerDetected;
        isPlayerInAttackArea = goblin.CollisionSense.PlayerInAttackArea;

        if (isPlayerDetected)
        {
            //플레이어가 공격범위에 있고 공격 쿨타임이 지났으면
            if (isPlayerInAttackArea)
            {
                if (!goblin.Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                    ChangeIdleAnim();

                if (goblin.AttackState.CheckAttackCoolTime())
                    stateMachine.ChangeState(goblin.AttackState);
            }

            //앞쪽에 땅이 있고 벽이 없고 CheckPlayerFollow가 true면 플레이어를 따라간다. 
            else if (!isCliffing && !isTouchingWallFront && CheckPlayerFollow())
            {
                if (goblin.Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    ChangeMoveAnim();
                    Debug.Log("move animation");
                }

                goblin.Movement.PlayerDirectionFlip(goblin.CollisionSense.PlayerDirection);
                goblin.Movement.SetVelocityX(stateData.movementVelocity * goblin.CollisionSense.PlayerDirection);
            }
        }
        else
        {
            if (goblin.Anim.GetCurrentAnimatorStateInfo(0).IsName("Move"))
                ChangeIdleAnim();

            stateMachine.ChangeState(goblin.IdleState);
        }
    }

    private bool CheckPlayerFollow()
    {
        //Enemy와 Player간의 거리가 Enemy의 콜라이더 사이즈보다 크면 따라간다
        if (Mathf.Abs(goblin.CollisionSense.playerCol.transform.position.x - goblin.transform.position.x) > goblin.CollisionSense.playerCol.bounds.size.x)
            return true;
        else
            return false;
    }

    private void ChangeIdleAnim()
    {
        goblin.Anim.SetBool("move", false);
        goblin.Anim.SetBool("idle", true);
    }

    private void ChangeMoveAnim()
    {
        goblin.Anim.SetBool("idle", false);
        goblin.Anim.SetBool("move", true);
    }
}
