using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected Core core;

    protected Enemy enemy;
    protected EnemyStateMachine stateMachine;
    protected SO_EnemyData enemyData;

    protected bool isAnimationFinished;
    protected bool isExitingState;

    protected float startTime;

    protected string animBoolName;

    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, SO_EnemyData enemyData, string animBoolName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.enemyData = enemyData;
        this.animBoolName = animBoolName;
        core = enemy.Core;
    }

    //해당 State가 시작될 때 한 번 실행
    public virtual void Enter()
    {
        DoChecks();
        enemy.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        isAnimationFinished = false; //새로운 상태로 변경 될 때 애니메이션 시작
        isExitingState = false;
    }

    //해당 State가 끝날 때 한 번 실행
    public virtual void Exit()
    {
        enemy.Anim.SetBool(animBoolName, false);
        isExitingState = true;
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }

    public virtual void AnimationTrigger()
    {

    }

    public virtual void AnimationFinishTrigger()
    {
        isAnimationFinished = true;
    }
}
