using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootBehaviour : MonoBehaviour
{
    public Transform ShootSpot;
    public Projectile targetBullet;

    public PlayerStats pStats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShootBullet()
    {
        var projectile = GameObject.Instantiate(targetBullet);
        projectile.GetComponent<Projectile>().Damage = pStats.Attack;
        projectile.direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        projectile.transform.position = ShootSpot.position;
        projectile.color = Color.white;
    }
}
