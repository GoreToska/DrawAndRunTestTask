using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour, IInteractable
{
    public void Interact(GameObject interactable = null)
    {
        if (!interactable)
            return;

        interactable.GetComponent<IInteractable>().Interact();
    }
}
