using UnityEngine;
using UnityEngine.InputSystem;

public class Shread : MonoBehaviour
{
    public void Do(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            Destroy(gameObject);
        }
    }
}
