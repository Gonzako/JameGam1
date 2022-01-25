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



    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * speed;
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.transform.up = direction.normalized;
        sr.color = color;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != this.gameObject.name && collision.gameObject.tag != "Enemy")
        Destroy(this.gameObject);
    }
}
