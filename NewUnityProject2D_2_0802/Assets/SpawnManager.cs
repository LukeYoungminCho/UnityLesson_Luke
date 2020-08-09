using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoSingleTon<SpawnManager>
{ 
    public BoxCollider2D spawnArea;

    public Enemy SpawnEnemy(GameObject prefab)
    {
        if(prefab.GetComponent<Enemy>() == null)
        {
            Debug.LogError("Enemy 스크립트를 찾을 수 없는 오브젝트를 생성 시도했습니다");
            return null;
        }
        else
        {
            GameObject obj = Instantiate(prefab);
            obj.transform.position = GetSpawnPosition();
            Enemy script = obj.GetComponent<Enemy>();
            return script;
        }
    }

    public Vector3 GetSpawnPosition()
    {
        float minX = spawnArea.transform.position.x - spawnArea.size.x ;
        float maxX = spawnArea.transform.position.x + spawnArea.size.x ;
        float minY = spawnArea.transform.position.y - spawnArea.size.x ;
        float maxY = spawnArea.transform.position.y + spawnArea.size.x ;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }
}

