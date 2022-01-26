using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FallingProjectile : MonoBehaviour
{
    public Vector2 targetPosition;
    private Collider2D selfCollider;

    private void Awake()
    {
        selfCollider = GetComponent<Collider2D>();
        selfCollider.enabled = false;
    }

    IEnumerator movementRoutine()
    {
        yield return null;
        float seconds = Random.Range(1f, 3f);
        transform.DOMove(targetPosition, Random.Range(1f, 3f));
    }
}
