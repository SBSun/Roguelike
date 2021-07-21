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
            //�÷��̾ ���ݹ����� �ְ� ���� ��Ÿ���� ��������
            if (isPlayerInAttackArea)
            {
                if (!goblin.Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                    ChangeIdleAnim();

                if (goblin.AttackState.CheckAttackCoolTime())
                    stateMachine.ChangeState(goblin.AttackState);
            }

            //���ʿ� ���� �ְ� ���� ���� CheckPlayerFollow�� true�� �÷��̾ ���󰣴�. 
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
        //Enemy�� Player���� �Ÿ��� Enemy�� �ݶ��̴� ������� ũ�� ���󰣴�
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
