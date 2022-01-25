using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        var direction = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
        transform.rotation = rotation;
    }

}
