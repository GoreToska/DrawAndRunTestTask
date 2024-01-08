using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour, IInteractable
{
    [SerializeField] private float radius;
    [SerializeField] private ParticleSystem _blow;
    [SerializeField] private LayerMask layerMask;

    public void Interact(GameObject interactable = null)
    {
        var colliders = Physics.OverlapSphere(transform.position, radius, layerMask);

        foreach (var collider in colliders)
        {
            collider.GetComponent<IInteractable>().Interact();
        }
        
        _blow.Play(true);
        Destroy(gameObject, 0.6f);
    }
}
