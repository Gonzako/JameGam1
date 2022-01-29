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

    public void Powerup()
    {
        Health += 1;
        Speed += 0.2f;
        Attack += 1;
        FireRate += 2f;

        this.GetComponent<playerShootInput>().shootSpeed += FireRate;

        // todo update ui
        var playerInfo = GameObject.FindGameObjectWithTag("CANVAS").transform.Find("PlayerInfo").gameObject;
        playerInfo.GetComponent<PlayerHearts>().UpdateUI();
    }


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PlayerHitDetection.OnPlayerHit += TakeDamage;
    }


    // Update is called once per frame
    void Update()
    {
        //playerText.text = "HP: " + Health;

        
    }

    public void TakeDamage(int value)
    {
        playerInfo.GetComponent<PlayerHearts>().RemoveHearts(value);
        Health -= value;
    }

    private void OnDisable()
    {
        PlayerHitDetection.OnPlayerHit -= TakeDamage;
    }

}
