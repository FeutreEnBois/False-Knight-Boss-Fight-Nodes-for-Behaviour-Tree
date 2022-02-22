using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using DG.Tweening;

public class JumpNode : ActionNode
{
    public float horizontalForce = 5.0f;
    public float jumpForce = 10.0f;

    public float buildupTime;
    public float jumpTime;

    public string animationTriggerName;
    public bool shakeCameraOnLanding;

    public bool hasLanded;

    private Tween buildupTween;
    private Tween jumpTween;

    protected override void OnStart() {
        buildupTween = DOVirtual.DelayedCall(buildupTime, StartJump, false);
        context.animator.SetTrigger(animationTriggerName);
    }

    private void StartJump()
    {
        var direction = context.player.transform.position.x < context.transform.position.x ? -1 : 1;
        context.body.AddForce(new Vector2(horizontalForce * direction, jumpForce), ForceMode2D.Impulse);

        jumpTween = DOVirtual.DelayedCall(jumpTime, () =>
        {
            hasLanded = true;
            if (shakeCameraOnLanding)
            {
                context.camera.ShakeCamera(0.5f);
            }
        },false);
    }

    protected override void OnStop() {
        buildupTween?.Kill();
        jumpTween?.Kill();
        hasLanded=false;
    }

    protected override State OnUpdate() {
        return hasLanded ? State.Success : State.Running;
    }
}
