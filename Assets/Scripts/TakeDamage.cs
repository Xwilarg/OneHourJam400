using TMPro;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private Rigidbody2D _rb;
    private TMP_Text _complain;

    private string[] _complainList = new[]
    {
        "Stop that!",
        "Outch!",
        "I will call security!"
    };

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _complain = GetComponentInChildren<TMP_Text>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _rb.AddForce((transform.position - collision.collider.transform.position).normalized * 10f, ForceMode2D.Impulse);
            _complain.text = _complainList[Random.Range(0, _complainList.Length)];
        }
    }
}
