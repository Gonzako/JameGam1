using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitOnDeath : MonoBehaviour
{

    public GameObject spawn1;
    public GameObject spawn2;
    Vector3 trans1;
    Vector3 trans2;

    private void OnDestroy()
    {
        if (PlayerReferencer.PlayerInstance != null)
        {
            trans1 = new Vector3(randF(), randF(), 0f);
            Instantiate(spawn1, transform.position + trans1, Quaternion.identity);

            trans2 = new Vector3(randF(), randF(), 0f);
            Instantiate(spawn2, transform.position + trans2, Quaternion.identity);
        }
        
    }

    private float randF()
    {
        return Random.Range(0f, 2.5f);
    }
}
