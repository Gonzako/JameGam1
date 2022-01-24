using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class staticEventExample : MonoBehaviour
{
    public static event Action<player> onPlayerDoneInitalizing = null;

    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        onPlayerDoneInitalizing += StaticEventExample_onPlayerDoneInitalizing;
    }
    // Start is called before the first frame update
    void Start()
    {
        //do stuff
    }
    private void StaticEventExample_onPlayerDoneInitalizing(player obj)
    {
        throw new NotImplementedException();
    }

    private void OnDisable()
    {
        onPlayerDoneInitalizing -= StaticEventExample_onPlayerDoneInitalizing;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}


public class player : IDamageable
{
    public void onHurt()
    {

    }
}

public interface IDamageable
{
    void onHurt();
}