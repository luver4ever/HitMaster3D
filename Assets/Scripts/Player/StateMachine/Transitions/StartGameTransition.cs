using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameTransition : Transition
{
    [SerializeField] private StartGameButton _startButton;

    protected override void Enable()
    {
        _startButton.GameStarted += OnGameStart;
    }
private void OnDisable()
    {
        _startButton.GameStarted -= OnGameStart;
    }

    private void OnGameStart()
    {
        NeedTransit = true;
    }


}
