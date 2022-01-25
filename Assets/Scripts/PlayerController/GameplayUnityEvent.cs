using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameplayUnityEvent : MonoBehaviour
{
    public UnityEvent OnBeginGameplay = new UnityEvent();
    public UnityEvent OnLeaveGameplay = new UnityEvent();

    private void OnEnable()
    {
        BasicGameLogic.OnBeginGameplay += OnBeginGameplay.Invoke;
        BasicGameLogic.OnLeaveGameplay += OnLeaveGameplay.Invoke;
    }
    private void OnDisable()
    {
        BasicGameLogic.OnBeginGameplay -= OnBeginGameplay.Invoke;
        BasicGameLogic.OnLeaveGameplay -= OnLeaveGameplay.Invoke;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
