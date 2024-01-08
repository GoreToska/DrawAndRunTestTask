using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, IInteractable
{
    public void Interact(GameObject interactable = null)
    {
        // add gold
        Destroy(gameObject);
    }
}

public interface IInteractable
{
    public void Interact(GameObject interactable = null);
}