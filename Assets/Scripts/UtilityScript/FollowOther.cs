using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOther : MonoBehaviour
{
    public Transform leader;


    void Update()
    {
        if (leader != null)
        transform.position = leader.transform.position;
    }
}
