using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathBehaviour : MonoBehaviour
{
    public int Health = 5;
    public GameObject deathParticle;

    public Color dieColor;


    public void Update()
    {
        if (Health <= 1)
        {


            var death = Instantiate(deathParticle, transform.position, Quaternion.identity);
            death.GetComponent<ParticleBehaviour>().particleColor = dieColor;
            GameObject.FindGameObjectWithTag("World").GetComponent<MainWorld>().EnemyKilled();
            Destroy(this.transform.parent.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Health -= 1;


            this.GetComponent<AudioSource>().Play();
        }
        
    }
}
