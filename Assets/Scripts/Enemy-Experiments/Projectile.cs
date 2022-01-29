using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 direction;
    public int speed;
    public Color color;
    private SpriteRenderer sr;

    public Sprite[] candy_bullets;

    public float Damage = 1;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * speed;
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.transform.up = direction.normalized;
        sr.color = color;

        if (candy_bullets.Length > 0)
        {
            sr.sprite = candy_bullets[Random.Range(0, candy_bullets.Length)];
        }

        StartCoroutine(DespawnTimer(7f));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        // ignore player and other Bullets
        if(collision.transform.CompareTag("Player") || collision.transform.CompareTag("Projectile"))
            Physics2D.IgnoreCollision(collision.transform.GetChild(0).gameObject.GetComponent<Collider2D>(), this.transform.GetChild(0).gameObject.GetComponent<Collider2D>());
        
        else //if (collision.transform.gameObject.layer == 0 ) // destroy if it hits environment
        {
            // todo: implement enemy system (example: collision.gameObject.GetComponent<Enemy>().HitEnemy(damageValue);  )
            
            Destroy(this.gameObject);
        }
            
    }

    IEnumerator DespawnTimer(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.transform.gameObject);
    }
}
