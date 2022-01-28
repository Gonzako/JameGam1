using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeStopper : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("should be stopping to move now!");
        GetComponent<ChargeAttack>().charging = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
