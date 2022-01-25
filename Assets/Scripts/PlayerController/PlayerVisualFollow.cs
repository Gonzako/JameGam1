using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisualFollow : MonoBehaviour
{
    [SerializeField]
    Transform PlayerLogic;
    bool followPlayer = false;

    private void OnEnable()
    {
        BasicGameLogic.OnBeginGameplay += EnableTrack;
        BasicGameLogic.OnLeaveGameplay += DisableTrack;
    }
    private void OnDisable()
    {

        BasicGameLogic.OnBeginGameplay -= EnableTrack;
        BasicGameLogic.OnLeaveGameplay -= DisableTrack;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = PlayerLogic.position;
    }

    void EnableTrack()
    {
        followPlayer = true;
    }

    void DisableTrack()
    {
        followPlayer = false;
    }
}
