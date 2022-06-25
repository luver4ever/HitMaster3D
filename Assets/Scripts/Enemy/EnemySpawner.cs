using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{

    public void SpawnEnemy(Enemy enemyPrefab, List<Enemy> enemyList, EnemySpawnPoint spawnPoint, UnityAction<Enemy> OnEnemyDie)
    {
        var newEnemy = Instantiate(enemyPrefab, spawnPoint.transform);

        enemyList.Add(newEnemy);

        newEnemy.Dying += OnEnemyDie;
    }
}
