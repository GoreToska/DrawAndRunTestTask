using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyPickUp : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject prefab;

    public void Interact(GameObject interactable = null)
    {
        PlayerHolder.OnGuyPickUp(Instantiate(prefab, parent).GetComponent<SplinePositioner>());
        Destroy(this.gameObject);
    }
}
