using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public GameObject target;
    public int speed = 7;
    public Rigidbody2D rb;
    public Color bulletColor;


    // Update is called once per frame

    private void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();
    }

   

    void Update()
    {
        if(target != null)
        {
            rb.velocity =  (target.transform.position - transform.position).normalized * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        transform.parent.GetChild(1).transform.position = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
