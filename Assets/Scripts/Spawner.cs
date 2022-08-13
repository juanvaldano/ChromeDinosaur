using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void SpawnEnemy(GameObject enemy)
    {
        enemy.transform.position = transform.position;
        enemy.gameObject.SetActive(true);
    }
}
