using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeStopper : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("should be stopping to move now!");
        this.transform.parent.GetComponent<ChargeAttack>().charging = false;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
