using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public GameObject target;
    public int speed = 7;
    public Rigidbody2D rb;
    public Projectile bulletPrefab;

    float distance;
    public float followDistance = 5f;


    public float lastFired;
    public float cooldown = 2;

    [SerializeField]
    Transform targetShooter;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        lastFired = Time.time;
        
    }


    void Update()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        targetShooter.right = (target.transform.position - transform.position).normalized;
        if (target != null && distance > followDistance)
        {
            rb.velocity = (target.transform.position - transform.position).normalized * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
            if (lastFired + cooldown < Time.time) // see if cooldown time has passed
            {
                ShootShotgun();
            }
        }
    }

    void ShootShotgun()
    {
       
        if (target != null)
        {
            for (int i = 0; i < 3; i++)
            {

                Projectile bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.direction = targetShooter.GetChild(i).right;

            }
        }

        lastFired = Time.time;
    }
}
