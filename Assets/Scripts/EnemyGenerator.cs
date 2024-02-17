using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _delayBetweenSpawn;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool _pool;

    private void Start()
    {
        StartCoroutine(GenerateEnemies());
    }

    private IEnumerator GenerateEnemies()
    {
        var wait = new WaitForSeconds(_delayBetweenSpawn);

        while (enabled) 
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Enemy enemy = _pool.GetObject();

        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
        enemy.Operate();
    }
}
