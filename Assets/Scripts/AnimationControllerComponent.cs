using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationControllerComponent : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    private Animator _animator;
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Run();
    }

    public void Run()
    {
        _animator.SetTrigger("Run");
    }

    public void Dead()
    {
        _animator.SetTrigger("Dead");
        PlayerHolder.OnSplineFollowerDead(this.GetComponent<SplinePositioner>());
        _particleSystem.Play();
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    public void Win()
    {
        _animator.SetTrigger("Win");
    }
}
