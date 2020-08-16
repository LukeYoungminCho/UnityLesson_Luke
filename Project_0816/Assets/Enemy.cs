using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum eState
    {
        Invalid,
        Idle,
        Trace,
        Attack,
        Dead,
    }

    private eState curState = eState.Invalid;

    private void Start()
    {
        ChangeState(eState.Idle);

    }
    private void Update()
    {
        
    }

    private void ChangeState(eState targetState)
    {
        if (curState == targetState)
            return;

        switch (curState)
        {
            case eState.Invalid:
                OnExitInvalidState();
                break;
            case eState.Idle:
                OnExitIdleState();
                break;
            case eState.Trace:
                OnExitTraceState();
                break;
            case eState.Attack:
                OnExitAttackState();
                break;
            case eState.Dead:
                OnExitDeadState();
                break;
            default:
                break;
        }
    }
    private void EnterState(eState targetState)
    {
        if (curState == targetState)
            return;

        switch (curState)
        {
            case eState.Invalid:
                OnEnterInvalidState();
                break;
            case eState.Idle:
                OnEnterIdleState();
                break;
            case eState.Trace:
                OnEnterTraceState();
                break;
            case eState.Attack:
                OnEnterAttackState();
                break;
            case eState.Dead:
                OnEnterDeadState();
                break;
            default:
                break;
        }
    }
    private void UpdateState(eState targetState)
    {
        if (curState == targetState)
            return;

        switch (curState)
        {
            case eState.Invalid:
                OnUpdateInvalidState();
                break;
            case eState.Idle:
                OnUpdateIdleState();
                break;
            case eState.Trace:
                OnUpdateTraceState();
                break;
            case eState.Attack:
                OnUpdateAttackState();
                break;
            case eState.Dead:
                OnUpdateDeadState();
                break;
            default:
                break;
        }
    }

    private void OnExitInvalidState()
    {

    }
    private void OnExitIdleState()
    {

    }
    private void OnExitTraceState()
    {

    }
    private void OnExitAttackState()
    {

    }
    private void OnExitDeadState()
    {

    }
    private void OnEnterInvalidState()
    {

    }
    private void OnEnterIdleState()
    {
        MoveRandomPoition();
    }

    private void MoveRandomPoition()
    {
        //get random target position
        float randomX = Random.Range(-5, 5) + transform.position.x;
        float randomZ = Random.Range(-5, 5) + transform.position.z;

        Vector3 targetPosition = new Vector3(randomX, transform.position.y, randomZ);

        StopCoroutine("MovePosition");
        StartCoroutine(MovePosition(targetPosition));
    }
    IEnumerator MovePosition(Vector3 targetPosition)
    {
        float distance = Vector3.Distance(transform.position, targetPosition);

        while (distance >= 0.05f)
        {
            transform.position += (targetPosition - transform.position).normalized *10f *Time.deltaTime;
            yield return null;
            distance = Vector3.Distance(transform.position, targetPosition);
        }
        
    }
    private void OnEnterTraceState()
    {

    }
    private void OnEnterAttackState()
    {

    }
    private void OnEnterDeadState()
    {

    }

    private void OnUpdateInvalidState()
    {

    }
    private void OnUpdateIdleState()
    {

    }
    private void OnUpdateTraceState()
    {

    }
    private void OnUpdateAttackState()
    {

    }
    private void OnUpdateDeadState()
    {

    }
}
