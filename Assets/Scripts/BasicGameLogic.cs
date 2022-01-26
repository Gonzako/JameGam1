using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGameLogic : MonoBehaviour
{
    public static event Action OnBeginGameplay = null;
    public static event Action OnLeaveGameplay = null;

    public static event Action OnLevelEnter = null;

    // Start is called before the first frame update
    void Start()
    {
        OnBeginGameplay?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginNextLevel()
    {
        OnLevelEnter?.Invoke();
    }

    public void BeginCutscene()
    {
        OnLeaveGameplay?.Invoke();
    }

    public void EndCutscene()
    {
        OnBeginGameplay?.Invoke();
    }
}
