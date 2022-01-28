using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadStacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHead(GameObject head)
    {
        if(this.transform.childCount > 0)
        {
            Destroy(this.transform.GetChild(0).gameObject);
        }
        var newHead = Instantiate(head, this.transform.position, Quaternion.identity);
        newHead.transform.parent = this.transform;
        newHead.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

}
