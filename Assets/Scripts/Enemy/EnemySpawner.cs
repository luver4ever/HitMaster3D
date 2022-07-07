using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{

    public Enemy SpawnEnemy(Enemy enemyPrefab, EnemySpawnPoint spawnPoint)
    {
        return Instantiate(enemyPrefab, spawnPoint.transform);
    }
}
