using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ChargeAttack : MonoBehaviour
{
    public GameObject target;
    public float speed = 1;
    public Rigidbody2D rb;
    public Color bulletColor;
    float lastCharge;
    public float cooldown = 3;
    bool charging = false;
    Vector2 tar;
    SpriteRenderer sr;

    void Start()
    {
        lastCharge = Time.time;
        rb = GetComponentInChildren<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastCharge + cooldown < Time.time)
        {
            tar = ((target.transform.position - rb.transform.position) * 50);
            charging = true;
            ChargeUp();            
        }
    }

    private async void ChargeUp()
    {
        
        sr.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        await Task.Delay(1000);
        sr.transform.localScale = new Vector3(1,1,1);

        transform.position = Vector2.MoveTowards(transform.position, tar, speed * Time.deltaTime);

        while (charging == true)
        {
            
            await Task.Yield();
        }
        lastCharge = Time.time;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collider hit");
        if (collision.gameObject.tag != "Enemy" && charging == true)
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponentInChildren<Collider2D>());
            charging = false;
        }
;
    }
}
