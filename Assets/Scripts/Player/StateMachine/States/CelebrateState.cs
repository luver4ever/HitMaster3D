using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrateState : State
{

    protected override void Enable()
    {
        Celebrate();
    }
    private void Celebrate()
    {
        PlayerAnimator.SetBool("Celebrate", true);
    }
    private void OnDisable()
    {
        PlayerAnimator.SetBool("Celebrate", false);
    }
}
