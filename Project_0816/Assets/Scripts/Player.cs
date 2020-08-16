using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public float atkFreezeTime;
    [HideInInspector]
    public bool isMovable = true;
    [Range(1, 100)]
    public float moveSpeed;

    private void Update()
    {
        Attack();
        Move();
    }

    IEnumerator Delay(float time)
    {
        yield return null;      
    }

    private void Move()
    {
        Vector3 dir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            dir += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += Vector3.right;
        }
        Debug.Log($"{ dir.x}{dir.y}{dir.z}");

        // 왜안되지이거??
        for (int i = 0; i < animator.parameterCount; i++)
        {  
            animator.SetBool(i,false);
            isMovable = true;
        }

        animator.SetBool("isRun_front",false);
        animator.SetBool("isRun_back", false);
        animator.SetBool("isRun_right", false);
        animator.SetBool("isRun_left", false);

        if (dir == transform.forward)
        {
            animator.SetBool("isRun_front", dir != Vector3.zero);            
        }
        else if(dir == transform.forward*-1)
        {
            animator.SetBool("isRun_back", dir != Vector3.zero);
        }
        else if (dir == transform.right)
        {
            animator.SetBool("isRun_right", dir != Vector3.zero);
        }
        else if (dir == transform.right*-1)
        {
            animator.SetBool("isRun_left", dir != Vector3.zero);
        }

        transform.position += dir.normalized * Time.deltaTime * moveSpeed;
    }

    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("triggerAttack");
            isMovable = false;
            StopCoroutine("Delay");
            StartCoroutine(Delay(atkFreezeTime));
        }
    }
}
