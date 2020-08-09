using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 공격을 담당하는 스크립트
public class PlayerWeapon : MonoBehaviour
{
    public GameObject missilePrefab;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject missileInstance = (GameObject)Instantiate(missilePrefab);
            Bullet script = missileInstance.GetComponent<Bullet>();
            script.ownerTag = gameObject.tag;
            missileInstance.transform.position = transform.position;
            //Destroy(missileInstance, 5f);
        }
    }
}
