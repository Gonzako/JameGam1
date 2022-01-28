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
    public float followDistance = 4f;
    public float speed = 4f;
    bool canWalk = true;

    public float lastShot;
    public float cooldown = 2f;

    public GameObject BOSS_UI;

    private void Awake()
    {
        BOSS_UI = GameObject.FindGameObjectWithTag("CANVAS").transform.Find("BossFight").gameObject;
    }

    void Start()
    {
        BOSS_UI.SetActive(true);
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        lastShot = Time.time;
    }

    void UpdateBossUI()
    {

    }

    void Update()
    {
        UpdateBossUI();

        FollowPlayer();
       
          
        if (lastShot + cooldown < Time.time && target != null)
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

    public async void LineShoot()
    {
        canWalk = false;
        for (int j = 0; j < 2; j++)
        {
            lineShooter.right = (target.transform.position - transform.position).normalized;

            for (int i = 0; i < lineShooter.childCount; i++)
            {
                // enemy has a list of points to shoot from
                Projectile bullet = Instantiate(bulletPrefab, lineShooter.GetChild(i).transform.position, Quaternion.identity);
                bullet.direction = lineShooter.GetChild(i).right;
            }
            lastShot = Time.time;
            await Task.Delay(500);
        }
        canWalk = true;
    }

    public async void CircleShoot()
    {
        canWalk = false;
        circleShooter.right = (target.transform.position - transform.position).normalized;

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
        canWalk = true;
    }

    public void FollowPlayer()
    {
        var dir = (target.transform.position - transform.position);

        if(dir.magnitude > followDistance && dir.magnitude < 15 && canWalk == true)
        {
            rb.velocity = Vector2.MoveTowards(rb.velocity, dir.normalized * speed, speed * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
