using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _rb.AddForce((transform.position - collision.collider.transform.position).normalized * 10f, ForceMode2D.Impulse);
        }
    }
}
