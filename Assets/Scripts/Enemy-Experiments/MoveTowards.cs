using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public GameObject target;
    public float speed = 1.3f;
    public Rigidbody2D rb;
    public Color bulletColor;
    public float keepDistance;


    // Update is called once per frame

    private void Start()
    {

        target = PlayerReferencer.PlayerInstance.PlayerLogic.gameObject;

        rb = GetComponent<Rigidbody2D>();
    }

   

    void Update()
    {
        if(target != null)
        {
            if ((target.transform.position - this.transform.position).sqrMagnitude < keepDistance)
            {
                // the player is within a radius of 3 units to this game object
                rb.velocity = Vector2.zero;
            }
            else
            {
                rb.velocity = (target.transform.position - transform.position).normalized * speed;
            }

            
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
