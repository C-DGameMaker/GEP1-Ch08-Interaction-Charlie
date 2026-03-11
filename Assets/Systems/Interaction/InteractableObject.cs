using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    public bool debugEnabled = true;
    public void Focused()
    {
        if (debugEnabled) Debug.Log("Focused");
    }

    public void Unfoucsed()
    {
        if (debugEnabled) Debug.Log("Unfocused");
    }


    public void Interact()
    {
        if (debugEnabled) Debug.Log("Interacted");
    }
}
