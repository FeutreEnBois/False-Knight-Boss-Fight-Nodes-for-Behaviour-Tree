using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using Core;

public class FreezeTime : ActionNode
{
    public float Duration = 0.1f;

    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        GameManager.Instance.FreezeTime(Duration);
        return State.Success;
    }
}
