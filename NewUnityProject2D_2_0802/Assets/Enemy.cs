using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class Enemy : Charactor
{
    public GameObject missilePrefab;
    public float AttackSpeed = 3f;

    private void Start()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        while(true)
        {
            Attack();
            yield return new WaitForSeconds(AttackSpeed * Time.deltaTime);
        }
    }
    void Attack()
    {
        GameObject missileInstance = (GameObject)Instantiate(missilePrefab);
        missileInstance.transform.position = transform.position;
        missileInstance.transform.Rotate(new Vector3(0, 0, 180));
        Bullet script = missileInstance.GetComponent<Bullet>();
        script.ownerTag = gameObject.tag;
    }

    public override void Hitted(Bullet bullet)
    {
        hp -= bullet.damage;

        if (hp < 0)
        {
            Destroy(gameObject);
            GameManager.Instance.score++;
            StageManager.Instance.EnemyDown(this);
        } 
    }
}
