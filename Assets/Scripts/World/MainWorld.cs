using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MainWorld : MonoBehaviour
{
    [SerializeField] Tilemap _baseGroundTileMap;
    [SerializeField] Tilemap _walkableObjectsTileMap;
    [SerializeField] Tilemap _obstaclesTileMap;

    [SerializeField] TileBase baseTileGround;

    [SerializeField] GameObject _playerReference;

    private void Awake()
    {
        _playerReference = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {


        // generate simple room
        Vector3Int roomStartPosition = new Vector3Int(-9, 0, 0);
        Vector3Int roomEndPosition = new Vector3Int(25, -7, 0);

        _baseGroundTileMap.DeleteCells(roomStartPosition, roomEndPosition);
        _walkableObjectsTileMap.DeleteCells(roomStartPosition, roomEndPosition);
        _obstaclesTileMap.DeleteCells(roomStartPosition, roomEndPosition);

        for(int y = -1; y > -7; y--)
        {
            for(int x = -9; x < 25; x++)
            {
                _baseGroundTileMap.SetTile(new Vector3Int(x, y, 0), baseTileGround);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        // get player position
        // check for tilepos (convert to playerpos to tilemappos)

        //var playerPos = playerPos;

    }
}
