using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourWayShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject target;
    public float cooldown = 1.5f;
    public float lastFired;
    public Color bulletColor;
    public Animator anim;


    Vector2[] shootingDirections = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        lastFired = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastFired + cooldown  < Time.time) // see if cooldown time has passed
        {
            ShootAround();
        }
    }


    public  void  ShootAround()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Projectile>().direction = shootingDirections[i];

            bullet.GetComponent<Projectile>().color = bulletColor;

            anim.Play("Attack");
        }
        
        lastFired = Time.time;

    }
}
