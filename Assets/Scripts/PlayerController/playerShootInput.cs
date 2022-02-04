using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShootInput : MonoBehaviour
{
    PlayerShootBehaviour shooter;
    float timer = 0;
    public float shootSpeed = 20;

    public PlayerStats pStats;

    // Start is called before the first frame update
    private void Awake()
    {
        shooter = GetComponent<PlayerShootBehaviour>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && timer < Time.time)
        {
            timer = Time.time + 10 / shootSpeed;
            shooter.ShootBullet();
        }
    }
}
