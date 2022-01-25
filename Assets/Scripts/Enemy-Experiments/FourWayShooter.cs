using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourWayShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject target;
    public float cooldown = 3;
    public float lastFired;
    public Color bulletColor;


    Vector2[] shootingDirections = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
    // Start is called before the first frame update
    void Start()
    {
        lastFired = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastFired + cooldown < Time.time) // see if cooldown time has passed
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

            bullet.GetComponent<Projectile>().color = this.GetComponent<SpriteRenderer>().color;
            
        }
        
        lastFired = Time.time;

    }
}
