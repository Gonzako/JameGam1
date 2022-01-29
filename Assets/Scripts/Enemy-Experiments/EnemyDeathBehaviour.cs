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

            int random = Random.Range(0, 100);
            if(random >= 80)
            {
                var item = Instantiate(PlayerReferencer.PlayerInstance.ItemHeads[Random.Range(0, 6)], this.transform.position, Quaternion.identity);
            }

            Destroy(this.transform.parent.gameObject);
        }


        // kill all enemies if they are out of bounds
        if (this.transform.position.y >= 0.52f || this.transform.position.y <= -5.18f)
        {
            GameObject.FindGameObjectWithTag("World").GetComponent<MainWorld>().EnemyKilled();
            Destroy(this.transform.parent.gameObject);
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Health -= (int)collision.gameObject.GetComponent<Projectile>().Damage;

            this.GetComponent<AudioSource>().Play();
        }
        
    }
}
