using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using Core.Combat;
using Core.Combat.Projectiles;


public class ShootNode : ActionNode
{
    //public List<Weapon> weapons;
    public bool shakeCamera;

    //public Transform weaponTransform;
    public AbstractProjectile projectilePrefab;
    public float horizontalForce = 1.0f;
    public float verticalForce = 0f;

    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        var projectile = Object.Instantiate(projectilePrefab, context.weaponTransf.position,
                Quaternion.identity);
        projectile.Shooter = context.gameObject;

        var force = new Vector2(horizontalForce * context.transform.localScale.x, verticalForce);
        projectile.SetForce(force);

        if (shakeCamera)
        {
            context.camera.ShakeCamera(0.5f);
        }

        //foreach (var weapon in weapons)
        //{
        //    Debug.Log(weapon.weaponTransform.position);
        //    var projectile = Object.Instantiate(weapon.projectilePrefab, context.transform.position,
        //        Quaternion.identity);
        //    projectile.Shooter = context.gameObject;

        //    var force = new Vector2(weapon.horizontalForce * context.transform.localScale.x, weapon.verticalForce);
        //    projectile.SetForce(force);

        //    if (shakeCamera)
        //    {
        //        context.camera.ShakeCamera(0.5f);
        //    }
        //}
        return State.Success;
    }
}
