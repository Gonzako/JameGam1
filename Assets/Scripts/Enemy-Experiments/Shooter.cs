using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject target;
    public float cooldown = 1;
    public float lastFired;
    public Color bulletColor;

    // Start is called before the first frame update
    void Start()
    {
        lastFired = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(lastFired +  cooldown < Time.time) // see if cooldown time has passed
        {
            ShootAtTarget();
        }
    }


    public void ShootAtTarget()
    {
        if (target != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Projectile>().direction = target.transform.position - transform.position;

            bullet.GetComponent<Projectile>().color = this.GetComponent<SpriteRenderer>().color;
        }

        lastFired = Time.time;


    }
}
