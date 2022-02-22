using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class FacePlayerNode : ActionNode
{
    private float baseScaleX;
    protected override void OnStart() {
        baseScaleX = context.transform.localScale.x;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        var scale = context.transform.localScale;
        scale.x = context.transform.position.x > context.player.transform.position.x ? -baseScaleX : baseScaleX;
        context.transform.localScale = scale;
        return State.Success;
    }
}
