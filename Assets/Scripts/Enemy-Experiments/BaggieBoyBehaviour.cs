using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaggieBoyBehaviour : MonoBehaviour
{

    public FallingProjectile targetBullet;
    public float Precision = 0.5f;
    private Animator Anim;

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private void OnEnable()
    {
        StartCoroutine(shootRoutine());
    }
    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }
    private void doShootOut()
    {
        var targetedPosition = PlayerReferencer.PlayerInstance.PlayerLogic.position;
        var distance = Vector3.Distance(targetedPosition, transform.position);
        if (distance > 10f){
            return;
        }
        var targetBullets = Random.Range(4, 8);

        for(int i = 0; i < targetBullets; i++)
        {
            var bullet = Instantiate(targetBullet, transform.position, Quaternion.identity);
            bullet.targetPosition = (Vector2)targetedPosition + Random.insideUnitCircle/Precision;
        }
    }

    IEnumerator playAnimation()
    {
        //animator call first
        Anim.Play("BaggieBoyShoot");
        yield return new WaitForSeconds(0.2f);
    }

    IEnumerator shootRoutine()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        yield return StartCoroutine(playAnimation());
        StartCoroutine(shootRoutine());
    }
}
