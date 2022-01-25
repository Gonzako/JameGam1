using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DungeonGeneration : MonoBehaviour
{
    [SerializeField] readonly int DungeonHeight = 24;

    [SerializeField] int DungeonWidth = 0;

    [SerializeField] Tilemap dungeonTilemap;

    // Start is called before the first frame update
    void Start()
    {
        DungeonWidth = Random.Range(50, 200);

        // create basic tilemap 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
