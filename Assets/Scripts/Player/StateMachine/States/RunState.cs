using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class RunState : State
{
    private PlayerMover _playerMover;
    private Vector3 _targetPoint;

    private float _target;

    public UnityAction TargetReached;
    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
    }
    protected override void Enable()
    {
        _playerMover.PointUpdated += OnPointUpdate;
        _playerMover.MovePlayer();

        
        PlayerAnimator.SetBool("Run", true);
    }
    private void OnPointUpdate(Vector3 target)
    {
        _targetPoint = target;
    }

    private void Update()
    {
        
        _target = (transform.position - _targetPoint).magnitude;

        if (_target <= 1f)
            TargetReached?.Invoke();
    }
    private void OnDisable()
    {
        _playerMover.PointUpdated -= OnPointUpdate;
        PlayerAnimator.SetBool("Run", false);
    }


}
