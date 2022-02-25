using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using Core.Combat;

public class SpawnMaggot : ActionNode
{
    public GameObject maggotPrefab;

    private Destructable maggot;

    protected override void OnStart() {
        maggot = Object.Instantiate(maggotPrefab, context.maggotTransf).GetComponent<Destructable>();
        maggot.transform.localPosition = Vector3.zero;
        context.destructable.Invincible = true;
        context.hazardCollider.SetActive(false);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (maggot.CurrentHealth > 0) return State.Running;

        context.destructable.Invincible = false;
        context.hazardCollider.SetActive(false);
        return State.Success;
    }
}
