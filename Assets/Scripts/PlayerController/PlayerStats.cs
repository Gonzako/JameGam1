using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    private static PlayerStats instance = null; 

    public static PlayerStats PlayerStatsInstance { get { return instance; } }

    public int Health = 4;
    public float speed = 5f;
    public int defense = 0;
    public int attack = 1;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
