using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    private bool _canMove = false;

    private bool _isMoving = false;

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
        var mov = value.ReadValue<Vector2>();
        if (_canMove && !_isMoving)
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(mov.normalized * 10f, ForceMode2D.Impulse);
        }
        _isMoving = mov.x != 0f || mov.y != 0f;
    }
}
