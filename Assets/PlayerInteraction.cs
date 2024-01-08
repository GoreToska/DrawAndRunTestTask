using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(AnimationControllerComponent))]
public class PlayerInteraction : MonoBehaviour, IInteractable
{
    private AnimationControllerComponent _controller;

    private void Awake()
    {
        _controller = GetComponent<AnimationControllerComponent>();
        var pSpline = GetComponent<SplinePositioner>();
        Debug.Log(pSpline.spline);
    }

    public void Interact(GameObject interactable = null)
    {
        _controller.Dead();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IInteractable>().Interact(this.gameObject);
    }
}
