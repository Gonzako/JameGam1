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

    public GameObject particles = null;

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
        if(particles != null)
        {
            var p = Instantiate(particles, transform.position, Quaternion.identity);
        }
            
        Destroy(this.gameObject);
    }

    IEnumerator DespawnTimer(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }
}
