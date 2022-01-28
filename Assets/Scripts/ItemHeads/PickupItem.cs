using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public GameObject visualHead;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            PlayerReferencer.PlayerInstance.PlayerHeadStack.gameObject.GetComponent<HeadStacker>().AddHead(visualHead);
            PlayerReferencer.PlayerInstance.PlayerLogic.gameObject.GetComponent<PlayerStats>().Powerup();
            Destroy(this.gameObject);
        }
        
    }

}
