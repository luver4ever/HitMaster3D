using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Animator PlayerAnimator { get; private set; }
    private void OnEnable()
    {
        Enable();
    }
    public void Enter(Animator playerAnimator)
    {
        if(enabled == false)
        {
            PlayerAnimator = playerAnimator;

            enabled = true;

            foreach(var transition in _transitions)
                transition.enabled = true;
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
                transition.enabled = false;

            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
            if (transition.NeedTransit)
                return transition.TargetState;

        return null;
    }
    protected abstract void Enable();
}
