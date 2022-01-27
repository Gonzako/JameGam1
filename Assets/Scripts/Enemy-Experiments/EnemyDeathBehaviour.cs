using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathBehaviour : MonoBehaviour
{
    public int Health = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
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
