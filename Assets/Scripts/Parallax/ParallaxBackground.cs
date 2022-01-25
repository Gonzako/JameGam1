using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float Length;
    public float StartPos;
    public GameObject objectToFollow;
    public float effectStrength;

    // Start is called before the first frame update
    void Start()
    {

        objectToFollow = GameObject.FindGameObjectWithTag("Player");


        StartPos = this.transform.position.x;
        Length = this.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceMoved = objectToFollow.transform.position.x * (1 - effectStrength);

        float distance = objectToFollow.transform.position.x * effectStrength;

        transform.position = new Vector3(StartPos + distance, this.transform.position.y, this.transform.position.z);

        if (distanceMoved > StartPos + Length + distance)
        {
            StartPos += Length;
        }
        else if (distanceMoved < StartPos - Length - distance)
        {
            StartPos -= Length;
        }

    }
}
