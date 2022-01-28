using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitDetection : MonoBehaviour
{
    public static event Action<int> OnPlayerHit = null;

    private void Start()
    {
        PlayerHitDetection.OnPlayerHit += PlayerDamaged; // for testing purposes, it is refenrencing itself, but it should work
    }

    private void PlayerDamaged(int value)
    {
        Debug.Log("player takes damage");
        PlayerStats.PlayerStatsInstance.TakeDamage(value);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.gameObject.layer == 8)  // 8 = EnemyBullets Collision Layer
        {
            OnPlayerHit?.Invoke(collision.gameObject.GetComponent<Projectile>().Damage);
        }
    }

    private void OnDisable()
    {
        PlayerHitDetection.OnPlayerHit -= PlayerDamaged;
    }
}
