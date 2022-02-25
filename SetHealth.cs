using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class SetHealth : ActionNode
{
    public int health;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        context.destructable.CurrentHealth = health;
        return State.Success;
    }
}
