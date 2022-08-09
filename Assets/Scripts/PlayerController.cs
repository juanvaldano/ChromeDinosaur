using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpForce;

    private bool _isGrounded;
    
    void Start()
    {
        _isGrounded = true;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            ToggleIsGrounded();
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
        }
    }

    public void ToggleIsGrounded()
    {
        _isGrounded = !_isGrounded;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Floor" && !_isGrounded)
        {
            ToggleIsGrounded();
        }

        if(collision.collider.tag == "Enemy")
        {
            GameManager.GMInstance.ResetGame();
        }
    }
}
