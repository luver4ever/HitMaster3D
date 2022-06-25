using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMover))]
public class CelebrateTransition : Transition
{
    [SerializeField] private Level _level;
    private PlayerMover _playeMover;

    private void Awake()
    {
        _playeMover = GetComponent<PlayerMover>();
    }
    protected override void Enable()
    {
        _level.CurrentPlatformEnded += OnCurrentPlatformEnd; 
    }
    private void OnDisable()
    {
        _level.CurrentPlatformEnded -= OnCurrentPlatformEnd;
    }
    private void OnCurrentPlatformEnd()
    {
        if (_playeMover.PointIndex == _playeMover.FinishPlatformIndex)
            NeedTransit = true;
    }
}
