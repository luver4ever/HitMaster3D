using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Platform : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _playerPoint;

    private EnemySpawnPoint[] _spawnPointsOfEnemies;
    private List<Enemy> _enemiesOnPlatform = new List<Enemy>();

    public Transform PlayerPoint => _playerPoint;

    public UnityAction PlatformEnded;

    private void Start()
    {
        _spawnPointsOfEnemies = GetComponentsInChildren<EnemySpawnPoint>();    

        for (int i = 0; i < _spawnPointsOfEnemies.Length; i++)
        {
            _spawner.SpawnEnemy(_enemyPrefab, _enemiesOnPlatform, _spawnPointsOfEnemies[i], OnEnemyDied);
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDied;
        
        _enemiesOnPlatform.Remove(enemy);

        if (_enemiesOnPlatform.Count == 0)
            PlatformEnded?.Invoke();
    }
}
