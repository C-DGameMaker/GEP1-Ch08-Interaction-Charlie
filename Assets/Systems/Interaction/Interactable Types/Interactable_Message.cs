using UnityEngine;

public class Interactable_Message : MonoBehaviour, IInteractable
{
    [SerializeField] UIManager _uiManager;

    [SerializeField] private string _message = "Please read me you fuck";

    private void Start()
    {
        _uiManager = ServiceHub.Instance.UIManager;
        if (_uiManager == null) Debug.LogError("UI not found");
    }
    public void Focused()
    {
    }

    public void Interact()
    {
        _uiManager.DisplayMessage(_message);
    }

    public void Unfoucsed()
    {
    }
}
