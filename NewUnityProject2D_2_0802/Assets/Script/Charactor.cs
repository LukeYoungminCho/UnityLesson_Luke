using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player 및 enemy 의 공통요소
public class Charactor : MonoBehaviour
{
    public float maxHp;
    public float hp;

    public virtual void Hitted(Bullet bullet)
    {
        hp -= bullet.damage;

        if(hp<0)
        {
            Destroy(gameObject);
        }
    }
}
