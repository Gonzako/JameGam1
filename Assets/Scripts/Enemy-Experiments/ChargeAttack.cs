using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ChargeAttack : MonoBehaviour
{
    public GameObject target;
    public float speed = 12f;
    public Rigidbody2D rb;
    public Color bulletColor;
    float lastCharge;
    public float cooldown = 0;
    public bool charging = false;
    Vector2 tar;
    SpriteRenderer sr;
    public float maxVelocity = 24f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        lastCharge = Time.time;
        rb = this.transform.GetChild(0).GetComponent<Rigidbody2D>();
        sr = this.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (lastCharge + cooldown < Time.time && charging == false)
        {
            rb.velocity = Vector2.zero;
            tar = ((target.transform.position - transform.position)).normalized;
            charging = true;
            ChargeUp();
        }
        transform.position = rb.transform.position;

        if (rb.velocity.x > maxVelocity)
        {
            rb.velocity = new Vector2(maxVelocity, rb.velocity.y);
        }

        if(rb.velocity.y > maxVelocity)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxVelocity);
        }

    }

    private async void ChargeUp()
    {
        //Debug.Log("charging...");
        rb.velocity = Vector3.zero;
        sr.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        await Task.Delay(100);
        sr.transform.localScale = new Vector3(1, 1, 1);

        Debug.Log(rb.velocity);
        //Debug.Log("Charge!");
        Debug.Log("" + tar + " / " + speed + " = " + tar*speed);
        rb.velocity = tar * speed * Time.deltaTime;
        Debug.Log(rb.velocity);

        await Task.Delay(300);
        charging = false;
        lastCharge = Time.time;
        rb.velocity = Vector3.zero;

        //Debug.Log("Charge Done!");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.FindGameObjectWithTag("World").GetComponent<MainWorld>().EnemyKilled();
        Destroy(this.gameObject);
    }


}

