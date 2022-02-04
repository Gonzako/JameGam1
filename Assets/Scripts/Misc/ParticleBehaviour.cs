using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    ParticleSystem ps;
    public Color particleColor;


    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.startColor = particleColor;
        StartCoroutine(DespawnTimer(7f));
    }

    IEnumerator DespawnTimer(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.transform.gameObject);
    }


}
