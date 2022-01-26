using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MainWorld : MonoBehaviour
{
    [SerializeField] Tilemap _baseGroundTileMap;
    [SerializeField] Tilemap _walkableObjectsTileMap;
    [SerializeField] Tilemap _obstaclesTileMap;

    #region Basic Ground Tiles
    [SerializeField] TileBase baseTileGround;
    [SerializeField] TileBase seamTileGround;
    #endregion

    #region Walkable Ground Tiles
    [SerializeField] TileBase walkableLollipop;
    #endregion

    #region Obstacle Ground Tiles
    [SerializeField] TileBase tileCloudObstacle;
    #endregion



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
            {
                TileBase tileToCreate = baseTileGround;
                Vector3Int currentTilePos = new Vector3Int(x, y, 0);

                if (y == 0) _obstaclesTileMap.SetTile(currentTilePos, seamTileGround); else _baseGroundTileMap.SetTile(currentTilePos, baseTileGround);

                if (x == startXPos && y != 0 && y != -3) _obstaclesTileMap.SetTile(currentTilePos, tileCloudObstacle);

                if (y == -5) _obstaclesTileMap.SetTile(currentTilePos, tileCloudObstacle);


            }
        }


    }

    void GenerateWorldStart()
    {
        for (int y = 0; y > -6; y--)
        {
            for (int x = -25; x < 10; x++)
            {
                TileBase tileToCreate = baseTileGround;
                Vector3Int currentTilePos = new Vector3Int(x, y, 0);

                if (y == 0) _obstaclesTileMap.SetTile(currentTilePos, seamTileGround); else _baseGroundTileMap.SetTile(currentTilePos, baseTileGround);

                if (x == -9 && y != 0) _obstaclesTileMap.SetTile(currentTilePos, tileCloudObstacle);

                if (y == -5) _obstaclesTileMap.SetTile(currentTilePos, tileCloudObstacle);


            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
