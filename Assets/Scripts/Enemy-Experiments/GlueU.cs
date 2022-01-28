using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class GlueU: MonoBehaviour
{
    Rigidbody2D rb;
    public Transform lineShooter;
    public Transform circleShooter;
    public Projectile bulletPrefab;
    public int shootinpoints;

    public GameObject target;

    public float lastShot;
    public float cooldown = 4f;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        lastShot = Time.time;
    }

    void Update()
    {
       
        lineShooter.right = (target.transform.position - transform.position).normalized;    
        if (lastShot + cooldown < Time.time)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    LineShoot();
                    break;
                case 1:
                    CircleShoot();
                    break;
                default:
                    // do nothing
                    break;
            }
        } 
    }

    public void LineShoot()
    {
        for (int i = 0; i < lineShooter.childCount; i++)
        {
            // enemy has a list of points to shoot from
            Projectile bullet = Instantiate(bulletPrefab, lineShooter.GetChild(i).transform.position, Quaternion.identity);
            bullet.direction = lineShooter.GetChild(i).right;
        }
        lastShot = Time.time;
    }

    public async void CircleShoot()
    {
        for (int j = 0; j < 4; j++)
        {
            for (int i = 0; i < circleShooter.childCount; i++)
            {
                // enemy has a list of points to shoot from
                Projectile bullet = Instantiate(bulletPrefab, circleShooter.GetChild(i).transform.position, Quaternion.identity);
                bullet.direction = circleShooter.GetChild(i).right;
            }
            lastShot = Time.time;

            await Task.Delay(250);
        } 
    }
}
