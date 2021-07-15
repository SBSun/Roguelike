using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected Enemy enemy;
    protected EnemyStateMachine stateMachine;

    protected float startTime;

    protected string animBoolName;

    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }
    //�ش� State�� ���۵� �� �� �� ����
    public virtual void Enter()
    {
        DoChecks();
        enemy.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
    }
    //�ش� State�� ���� �� �� �� ����
    public virtual void Exit()
    {
        enemy.Anim.SetBool(animBoolName, false);
    }
    //Update���� ����� ����
    public virtual void LogicUpdate()
    {

    }
    //Fixed Update���� ����� ����
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }
    public virtual void DoChecks()
    {

    }
}
