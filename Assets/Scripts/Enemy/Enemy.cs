using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider))]
public class Enemy : MonoBehaviour
{

    private Animator _animator;
    private Rigidbody _rigidbody;
    private Rigidbody[] _rigidbodies;
    private Collider _collider;

    public UnityAction<Enemy> Dying;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();

        _rigidbody.isKinematic = true;
        _collider.enabled = true;

        _rigidbodies = GetComponentsInChildren<Rigidbody>();

        for (int i = 0; i < _rigidbodies.Length; i++)
            _rigidbodies[i].isKinematic = true;
    }

    public void Die()
    {
        MakePhysical(_rigidbodies, _rigidbody);

        Dying?.Invoke(this);
    }

    private void MakePhysical(Rigidbody[] rigidbodies, Rigidbody rigidbody)
    {
        _collider.enabled = false;
        _animator.enabled = false;
        rigidbody.isKinematic = false;

        for (int i = 0; i < rigidbodies.Length; i++)
            rigidbodies[i].isKinematic = false;
    }
}
