using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReferencer : MonoBehaviour
{
    public static PlayerReferencer PlayerInstance;
    // Start is called before the first frame update
    [SerializeField]
    public Transform PlayerLogic;

    private void OnEnable()
    {
        if (PlayerInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            PlayerInstance = this;
        }
    }
    private void OnDisable()
    {
        if(PlayerInstance == this)
        {
            PlayerInstance = null;
        }
    }
}
