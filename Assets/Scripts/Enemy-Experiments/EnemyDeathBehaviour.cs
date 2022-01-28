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

            if(GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().isPlaying == false)
            {
                this.GetComponent<GlueU>().BOSS_UI.SetActive(false);
                GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().Play();
            }


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
