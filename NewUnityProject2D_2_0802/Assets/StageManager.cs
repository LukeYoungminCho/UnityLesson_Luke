using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class StageManager : MonoSingleTon<StageManager>
{
    public GameObject enemyPrefab;
    public int CurrentStage { get; private set; }
    public List<Enemy> enemyList = new List<Enemy>();
    public void StartStage(int stage)
    {
        Debug.Log($" 스테이지 {stage} 시작");
        CurrentStage = stage;
        ResetPlayerHP();
        MakeEnemies();
    }

    private void ResetPlayerHP()
    {
        Player.Instance.hp = Player.Instance.maxHp;
    }
    private void MakeEnemies()
    {
        for (int i = 0; i < CurrentStage*10; i++)
        {
            Enemy target = SpawnManager.Instance.SpawnEnemy(enemyPrefab);
            enemyList.Add(target);
        }
    }

    public void EnemyDown(Enemy target)
    {
        enemyList.Remove(target);
        if (enemyList.Count <= 0)
        {
            StartStage(++CurrentStage);
        }
    }
}
