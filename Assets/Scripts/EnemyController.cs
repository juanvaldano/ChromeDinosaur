using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed = 5;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
