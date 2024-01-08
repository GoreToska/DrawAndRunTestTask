using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour, IInteractable
{
    public void Interact(GameObject interactable = null)
    {
        if (!interactable)
            return;

        interactable.GetComponent<IInteractable>().Interact();
    }
}
