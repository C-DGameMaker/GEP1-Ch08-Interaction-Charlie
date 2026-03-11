using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionController : MonoBehaviour
{
    private IInteractable _targetInteractable;
    [SerializeField] GameObject _debug;

    [SerializeField] UIManager uIManager;

    private void Start()
    {
        uIManager = ServiceHub.Instance.UIManager;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out IInteractable foundInteractbale))
        {
            _targetInteractable = foundInteractbale;
            _debug = other.gameObject;

            uIManager.ShowPrompt();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable foundInteractbale))
        {
            _targetInteractable = null;
            _debug = null;

            uIManager.HidePrompt();
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
