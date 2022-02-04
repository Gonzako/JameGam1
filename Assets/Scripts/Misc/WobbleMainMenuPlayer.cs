using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WobbleMainMenuPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().DOShakePosition(0.1f, 0.6f, 10, 90, false, true);
    }
}
