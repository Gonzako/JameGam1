using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class GlueU: MonoBehaviour
{
    Rigidbody2D rb;
    public Transform lineShooter;
    public Transform circleShooter;
    public Projectile bulletPrefab;
    public int shootinpoints;

    public GameObject target;
    public float followDistance = 6f;
    public float speed = 4f;
    bool canWalk = true;

    public float lastShot;
    public float cooldown = 2f;

    public GameObject BOSS_UI;

    public Image healthBar;

    public Animator anim;

    public EnemyDeathBehaviour myDeathBehaviour;


    public int MaxHealth = 50;


    private void Awake()
    {
        myDeathBehaviour = this.GetComponent<EnemyDeathBehaviour>();

        BOSS_UI = GameObject.FindGameObjectWithTag("CANVAS").transform.Find("BossFight").gameObject;

        healthBar = BOSS_UI.transform.Find("BarBack").transform.GetChild(0).gameObject.GetComponent<Image>();

        MaxHealth = myDeathBehaviour.Health;

    }

    void Start()
    {
        BOSS_UI.SetActive(true);
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        lastShot = Time.time;
        anim = transform.parent.GetComponentInChildren<Animator>();
    }

    public void CalculateHealth()
    {
        var test = ((float)myDeathBehaviour.Health / MaxHealth) * 100;

        Debug.Log(test + "%");

        healthBar.fillAmount = test / 100;
    }

    void Update()
    {
        CalculateHealth();

        if (target == null)
        {
            return;
        }

        FollowPlayer();
       
          
        if (lastShot + cooldown < Time.time && target != null)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    StartCoroutine(LineShoot());
                    break;
                case 1:
                    StartCoroutine( CircleShoot());
                    break;
                default:
                    // do nothing
                    break;
            }
        } 
    }

    public IEnumerator LineShoot()
    {
        anim.Play("Attack");
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
            yield return new WaitForSeconds(0.25f);
        }
        canWalk = true;
        anim.Play("Idle");

    }

    public IEnumerator CircleShoot()
    {
        anim.Play("Attack");

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

            yield return new WaitForSeconds(0.25f);
        }
        canWalk = true;
        anim.Play("Idle");

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


    private void OnDestroy()
    {
        BOSS_UI.SetActive(false);

        StopCoroutine(LineShoot());
        StopCoroutine(CircleShoot());


    }
}
