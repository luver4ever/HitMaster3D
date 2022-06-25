using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerInput))]
public class AimState : State
{
    private PlayerInput _input;
    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
    }
    protected override void Enable()
    {
        _input.enabled = true;
        PlayerAnimator.SetBool("Aim", true); ;
    }
    private void OnDisable()
    {
        _input.enabled = false;
        PlayerAnimator.SetBool("Aim", false);
    }


}
