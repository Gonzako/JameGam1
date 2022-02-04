using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FallingProjectile : MonoBehaviour
{
    public Vector2 targetPosition;
    [SerializeField]
    private Collider2D selfCollider;
    public Transform BulletVisual;

    private void Awake()
    {
        selfCollider.enabled = false;
    }

    private void Start()
    {
        StartCoroutine(movementRoutine());
    }
    IEnumerator movementRoutine()
    {
        yield return null;
        float seconds = Random.Range(0.8f, 1.2f);
        BulletVisual.DOLocalJump(Vector3.up*0.35f, Random.Range(2 , 3), 1, seconds).SetEase(Ease.Linear);
        var rotationSequence = BulletVisual.DORotate(new Vector3(0,0,180), 0.2f);
        rotationSequence.SetDelay(seconds / 2.1f);
        transform.DOMove(targetPosition, seconds).SetEase(Ease.OutCubic);
        var timeToWait = seconds * 95 / 100;
        yield return new WaitForSeconds(timeToWait);
        selfCollider.enabled = true;
        //Spawn bullet death vfx code should go here
        yield return new WaitForSeconds(0.05f);
        Destroy(this.gameObject);
    }


}
