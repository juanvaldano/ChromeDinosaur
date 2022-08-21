using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Place enemy in the position of this GameObject and activate it
    public void SpawnEnemy(GameObject enemy)
    {
        enemy.transform.position = transform.position;
        enemy.gameObject.SetActive(true);
    }
}
