using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionController : MonoBehaviour
{
    private IInteractable _targetInteractable;
    [SerializeField] GameObject _debug;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out IInteractable foundInteractbale))
        {
            _targetInteractable = foundInteractbale;
            _debug = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable foundInteractbale))
        {
            _targetInteractable = null;
            _debug = null;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if (_targetInteractable == null) return;
            _targetInteractable.Interact();
        }
    }
}
