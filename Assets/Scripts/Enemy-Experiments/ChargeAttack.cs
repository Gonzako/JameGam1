using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ChargeAttack : MonoBehaviour
{
    public GameObject target;
    public float speed = 0.01f;
    public Rigidbody2D rb;
    public Color bulletColor;
    float lastCharge;
    public float cooldown = 3;
    bool charging = false;
    Vector2 tar;
    SpriteRenderer sr;
    public float maxVelocity = 2f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        lastCharge = Time.time;
        rb = GetComponentInChildren<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastCharge + cooldown < Time.time && charging == false)
        {
            rb.velocity = Vector2.zero;
            tar = ((target.transform.position - transform.position));
            charging = true;
            ChargeUp();
        }
        transform.position = rb.transform.position;

    }

    private async void ChargeUp()
    {
        rb.velocity = Vector2.zero;
        sr.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        await Task.Delay(1000);
        sr.transform.localScale = new Vector3(1, 1, 1);

        rb.velocity = tar.normalized * speed;

        await Task.Delay(3000);
        charging = false;
        lastCharge = Time.time;
        rb.velocity = Vector2.zero;



    }
}

