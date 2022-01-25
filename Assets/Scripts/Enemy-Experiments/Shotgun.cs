using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public GameObject target;
    public int speed = 7;
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Color bulletColor;

    float distance;
    public float followDistance = 5f;

    public float lastFired;
    public float cooldown = 2;
    float[] shootingAngles = {0, 30, -30}; // amount and degrees the shotguns shoots

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        lastFired = Time.time;
    }


    void Update()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);


        //moves to player and starts shooting at him with a shotgun
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
                bullet.GetComponent<Projectile>().direction = RotateVector(shootDir, shootingAngles[i]);
                bullet.GetComponent<Projectile>().color = bulletColor;
            }
        }

        lastFired = Time.time;
    }

    public Vector2 RotateVector(Vector2 vec, float angle)
    {
        // takes a Vector and rotates it by given angle and returns new vector
         
        angle +=  Vector2.Angle(Vector2.right, vec);
        angle *= Mathf.Deg2Rad;

        var NewVec2 = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        if (vec.y < 0)  // since it only goes to 180 degree, we need to flip the y here
        {
            NewVec2.y *= -1;
        }

        return NewVec2;
    }
}
