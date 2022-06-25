using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMover))]
public class AimTransition : Transition
{

    private RunState _runState;

    private void Awake()
    {
        _runState = GetComponent<RunState>();
    }
    protected override void Enable()
    {
        _runState.TargetReached += OnTargetReached;
    }
    private void OnDisable()
    {
        _runState.TargetReached -= OnTargetReached;
    }

    private void OnTargetReached()
    {
        NeedTransit = true;
    }


}
