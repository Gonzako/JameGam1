using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private static PlayerStats instance = null; 

    public static PlayerStats PlayerStatsInstance { get { return instance; } }

    public int Health = 4;
    public float Speed = 5f;
    public int Attack = 1;
    public float FireRate = 0f;

    public GameObject playerInfo;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        //playerText.text = "HP: " + Health;

        
    }

    public void TakeDamage()
    {
        playerInfo.GetComponent<PlayerHearts>().RemoveLastHeart();
        Health -= 1;
    }

}
