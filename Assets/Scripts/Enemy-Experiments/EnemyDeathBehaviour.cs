using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathBehaviour : MonoBehaviour
{
    public int Health = 5;
    public GameObject deathParticle;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Health -= 1;


            this.GetComponent<AudioSource>().Play();
        }
        if (Health <= 0)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("World").GetComponent<MainWorld>().EnemyKilled();
            Destroy(this.transform.parent.gameObject);
        }
    }
}
