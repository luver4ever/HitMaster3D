using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    private PlayerPoint[] _allPlayerPoints;
    private Platform[] _platforms;
    private Platform _currentPlatform;
    private int _platformIndex = 0;

    public int PlatformIndex => _platformIndex;
    public PlayerPoint[] PlayerPoints => _allPlayerPoints;
    public UnityAction CurrentPlatformEnded;

    private void Awake()
    {
        _allPlayerPoints = GetComponentsInChildren<PlayerPoint>();
        _platforms = GetComponentsInChildren<Platform>();

        SetNextPlatform();
    }

    private void OnPlatformEnd()
    {
        CurrentPlatformEnded?.Invoke();

        _currentPlatform.PlatformEnded -= OnPlatformEnd;

        SetNextPlatform();
    }

    private void SetNextPlatform()
    {
        if (_platformIndex < _platforms.Length)
        {
            _currentPlatform = _platforms[_platformIndex];
            _currentPlatform.PlatformEnded += OnPlatformEnd;
            
            _platformIndex++;
        }
    }
}
