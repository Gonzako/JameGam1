using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootBehaviour : MonoBehaviour
{
    public Transform ShootSpot;
    public Projectile targetBullet;
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
        projectile.direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        projectile.transform.position = ShootSpot.position;
        projectile.color = Color.blue;
    }
}
