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

    [SerializeField] GameObject prefabLevelTrigger;

    public int nextSegmentXPos = 0;

    private void Awake()
    {
        _playerReference = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        BasicGameLogic.OnLevelEnter += delegate
        {
            GenerateNextSegment(nextSegmentXPos);
        };

        // generate simple room
        Vector3Int roomStartPosition = new Vector3Int(-9, 0, 0);
        Vector3Int roomEndPosition = new Vector3Int(25, -7, 0);

        _baseGroundTileMap.DeleteCells(roomStartPosition, roomEndPosition);
        _walkableObjectsTileMap.DeleteCells(roomStartPosition, roomEndPosition);
        _obstaclesTileMap.DeleteCells(roomStartPosition, roomEndPosition);

        GenerateWorldStart();

        GenerateNextSegment(10);

    }

    void GenerateNextSegment(int startXPos)
    {
        int segmentWidth = Random.Range(15, 30);

        nextSegmentXPos = startXPos + segmentWidth - 1;
        Debug.Log(nextSegmentXPos);

        for (int y = 0; y > -6; y--)
        {
            for (int x = startXPos; x < startXPos+segmentWidth; x++)
            {
                Vector3Int currentTilePos = new Vector3Int(x, y, 0);

                if (y == 0)
                {
                    _obstaclesTileMap.SetTile(currentTilePos, seamTileGround);  
                }
                else
                {
                    _baseGroundTileMap.SetTile(currentTilePos, baseTileGround);
                    if(y != -3 && x >=2)
                    {
                        int random = Random.Range(0, 100);
                        if (random >= 85)
                        {
                            _obstaclesTileMap.SetTile(currentTilePos, tileCloudObstacle);
                        }
                    }
                    

                }
                if (x == startXPos && y != 0 && y != -3) _obstaclesTileMap.SetTile(currentTilePos, tileCloudObstacle);

                if (y == -5) _obstaclesTileMap.SetTile(currentTilePos, tileCloudObstacle);

                if(x == startXPos + segmentWidth -1 && y != 0) _obstaclesTileMap.SetTile(currentTilePos, tileCloudObstacle);
            
            }

            

        }

        int startPosBounds = startXPos + segmentWidth;

        for(int y = 0; y > -6; y--)
        {
            for(int x = startPosBounds; x < startPosBounds + 10; x++)
            {
                TileBase tileToCreate = baseTileGround;
                Vector3Int currentTilePos = new Vector3Int(x, y, 0);

                if (y == 0) _obstaclesTileMap.SetTile(currentTilePos, seamTileGround); else _baseGroundTileMap.SetTile(currentTilePos, baseTileGround);
            }
        }
        
        _obstaclesTileMap.SetTile(new Vector3Int(nextSegmentXPos, -3, 0), null);

        var levelTrigger = Instantiate(prefabLevelTrigger, new Vector3(startXPos + segmentWidth-1.25f, -1.85f, 0), Quaternion.identity);
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
