using JetBrains.Annotations;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    private bool _canMove = false;

    private bool _isMoving = false;

    public TMP_Text _secText;
    public TMP_Text _timer;
    public TMP_Text _bounce;
    private bool _timerOn = false;
    private float _timeLeft = 10f;
    private int _bCount = 0;

    public IEnumerator Reload()
    {
        _canMove = false;
        yield return new WaitForSeconds(1f);
        _canMove = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Boss"))
        {
            _timerOn = true;
            _secText.gameObject.SetActive(true);
            _timer.gameObject.SetActive(true);
            _bounce.gameObject.SetActive(true);
            _bCount++;
            _bounce.text = $"{_bCount} bounce{(_bCount > 1 ? "s" : "")}";
        }
    }

    private string Pad(int val)
    {
        if (val < 10) return $"0{val}";
        return val.ToString();
    }

    private void Update()
    {
        if (_timerOn)
        {
            _timeLeft -= Time.deltaTime;
            if (_timeLeft < 0f)
            {
                _timer.gameObject.SetActive(false);
                _secText.text = "Security took you out!";
                Destroy(gameObject);
                // GAMEOVER
            }
            else
            {
                _timer.text = $"{(int)(_timeLeft / 10)}:{Pad((int)(_timeLeft % 10))}";
            }
        }
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
