using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject enemyPrefab;

    private void Start()
    {
        enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
