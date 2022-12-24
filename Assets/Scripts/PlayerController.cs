using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    private bool _canMove = false;

    public IEnumerator Reload()
    {
        _canMove = false;
        yield return new WaitForSeconds(1f);
        _canMove = true;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void AllowMove(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            _canMove = true;
        }
    }

    public void Move(InputAction.CallbackContext value)
    {
        if (value.performed && _canMove)
        {
            var mov = value.ReadValue<Vector2>();
            _rb.velocity = Vector2.zero;
            _rb.AddForce(mov.normalized * 10f, ForceMode2D.Impulse);
        }
    }
}
