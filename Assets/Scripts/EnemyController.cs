using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        MoveLeft();
    }

    //The enemy adds itself to the Spawn Manager enemy queue and deactiavtes itself
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpawnManager.SMInstance.AddEnemyToQueue(gameObject);
        gameObject.SetActive(false);
    }

    private void MoveLeft()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}
