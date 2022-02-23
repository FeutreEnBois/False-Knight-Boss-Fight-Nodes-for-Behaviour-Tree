using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using Core.Combat;

public class ShootNode : ActionNode
{
    public List<Weapon> weapons;
    public bool shakeCamera;

    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        foreach (var weapon in weapons)
        {
            Debug.Log(weapon.weaponTransform.position);
            var projectile = Object.Instantiate(weapon.projectilePrefab, weapon.weaponTransform.position,
                Quaternion.identity);
            projectile.Shooter = context.gameObject;

            var force = new Vector2(weapon.horizontalForce * context.transform.localScale.x, weapon.verticalForce);
            projectile.SetForce(force);

            if (shakeCamera)
            {
                context.camera.ShakeCamera(0.5f);
            }
        }
        return State.Success;
    }
}
