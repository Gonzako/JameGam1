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
    float[] shootingAngles = {0, 15, -15};
    [SerializeField]
    Transform targetShooter;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponentInChildren<Rigidbody2D>();
        lastFired = Time.time;
    }


    void Update()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        targetShooter.right = (target.transform.position - transform.position).normalized;
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

                Projectile bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.direction = targetShooter.GetChild(i).right;

            }
        }

        lastFired = Time.time;
    }
    /*
    public Vector2 RotateVector(Vector2 vec, float angle)
    {
        // not working properly yet. Cant distinguish between above and below

        // takes a Vector and rotates it by given angle and returns new vector
         
        angle +=  Vector2.Angle(Vector2.right, vec);
        angle *= Mathf.Deg2Rad;

        

        return new Vector2(Mathf.Cos(angle),angle>180? Mathf.Sin(angle):-Mathf.Sin(angle));
    }*/
}
