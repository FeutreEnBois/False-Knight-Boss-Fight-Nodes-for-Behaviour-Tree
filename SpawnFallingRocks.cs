using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using Core.Combat.Projectiles;
using DG.Tweening;

public class SpawnFallingRocks : ActionNode
{
    public BoxCollider2D spawnRocksArea;
    public AbstractProjectile rockPrefab;
    public int spawnCount = 4;
    public float spawnInterval = 0.3f;

    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        var sequence = DOTween.Sequence();
        for (int i = 0; i < spawnCount; i++)
        {
            sequence.AppendCallback(SpawnRock);
            sequence.AppendInterval(spawnInterval);
        }

        return State.Success;
    }

    private void SpawnRock()
    {
        var randomX = Random.Range(spawnRocksArea.bounds.min.x, spawnRocksArea.bounds.max.x);
        var rock = Object.Instantiate(rockPrefab, new Vector3(randomX,
            spawnRocksArea.bounds.min.y), Quaternion.identity);
        rock.SetForce(Vector2.zero);
    }
}
