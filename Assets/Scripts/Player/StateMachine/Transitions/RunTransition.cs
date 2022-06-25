using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTransition : Transition
{
    [SerializeField] private Level _level;

    protected override void Enable()
    {
        _level.CurrentPlatformEnded += OnCurrentPlatformEnded;
    }
    private void OnDisable()
    {
        _level.CurrentPlatformEnded -= OnCurrentPlatformEnded;
    }

    private void OnCurrentPlatformEnded()
    {
        if(_level.PlatformIndex != _level.PlayerPoints.Length - 1)
        NeedTransit = true;
    }

 
}
