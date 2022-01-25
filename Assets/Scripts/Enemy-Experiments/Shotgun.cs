using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public GameObject target;
    public int speed = 7;
    public Rigidbody2D rb;
    public GameObject bulletPrefab;

    float distance;
    public float followDistance = 5f;

    public float lastFired;
    public float cooldown = 2;
    float[] shootingAngles = {0, 30, -30};

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponentInChildren<Rigidbody2D>();
        lastFired = Time.time;
    }


    void Update()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (target != null && distance > followDistance)
        {
            //rb.velocity = (target.transform.position - transform.position).normalized * speed;

            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
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
            for (int i = 0; i < shootingAngles.Length; i++)
            {
                Vector2 shootDir = (target.transform.position - transform.position);
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponentInChildren<Projectile>().direction = RotateVector(shootDir, shootingAngles[i]);
                bullet.GetComponentInChildren<Projectile>().color = this.GetComponentInChildren<SpriteRenderer>().color;
            }
        }

        lastFired = Time.time;
    }

    public Vector2 RotateVector(Vector2 vec, float angle)
    {
        // not working properly yet. Cant distinguish between above and below

        // takes a Vector and rotates it by given angle and returns new vector
         
        angle +=  Vector2.Angle(Vector2.right, vec);
        angle *= Mathf.Deg2Rad;

        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }
}
