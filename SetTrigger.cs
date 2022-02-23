using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using DG.Tweening;

public class SetTrigger : ActionNode
{
    public string animationTriggerName;

    protected override void OnStart() {

        context.animator.SetTrigger(animationTriggerName);

    }

    protected override void OnStop() {

    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
