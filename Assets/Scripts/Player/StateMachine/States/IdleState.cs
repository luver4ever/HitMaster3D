using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private void OnDisable()
    {
        PlayerAnimator.SetBool("Idle", false);
    }

    protected override void Enable()
    {
        PlayerAnimator.SetBool("Idle", true);
    }
}
