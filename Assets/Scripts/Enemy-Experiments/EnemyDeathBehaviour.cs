using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            GameObject.FindGameObjectWithTag("World").GetComponent<MainWorld>().EnemyKilled();

            this.GetComponent<AudioSource>().Play();

            Destroy(this.transform.parent.gameObject);
        }




    }
}