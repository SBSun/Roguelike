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
    //해당 State가 시작될 때 한 번 실행
    public virtual void Enter()
    {
        DoChecks();
        enemy.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
    }
    //해당 State가 끝날 때 한 번 실행
    public virtual void Exit()
    {
        enemy.Anim.SetBool(animBoolName, false);
    }
    //Update에서 실행될 내용
    public virtual void LogicUpdate()
    {

    }
    //Fixed Update에서 실행될 내용
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }
    public virtual void DoChecks()
    {

    }
}
