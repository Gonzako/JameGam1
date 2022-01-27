using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class MainWorld : MonoBehaviour
{
    [SerializeField] int LevelIndex = 0;

    [SerializeField] GameObject WorldTileMap;

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

    [SerializeField] GameObject[] enemyPrefabs;


    [SerializeField] GameObject _playerReference;

    [SerializeField] GameObject prefabLevelTrigger;

    [SerializeField] GameObject leftBorderWall;

    public int currentSegmentXPos = 0;

    public int nextSegmentXPos = 0;

    public bool levelEntered = false;

    public int CurrentEnemeyCount = 0;


    private void Awake()
    {
        _playerReference = GameObject.FindGameObjectWithTag("Player");
    }

    public void EnemyKilled()
    {
        CurrentEnemeyCount -= 1;
    }

    void DeleteAllTiles()
    {

        _baseGroundTileMap.ClearAllTiles();
        _walkableObjectsTileMap.ClearAllTiles();
        _obstaclesTileMap.ClearAllTiles();

    }

    private void OnDisable()
    {
        BasicGameLogic.OnLevelEnter -= null;
    }

    // Start is called before the first frame update
    void Start()
    {
        BasicGameLogic.OnLevelEnter += delegate
        {
            if(LevelIndex > 3)
            {
                LevelIndex = 0;
                DeleteAllTiles();
                _playerReference.GetComponentInChildren<PlayerMovement>().gameObject.transform.position = new Vector3(0, -2, 0);
                GenerateWorldStart();
                GenerateNextSegment(10);
                leftBorderWall.transform.position = new Vector3(-25f, -1.75f, 0);
            }
            else
            {
                _obstaclesTileMap.SetTile(new Vector3Int(nextSegmentXPos, -3, 0), null);
                GenerateNextSegment(nextSegmentXPos);
            }

            if(LevelIndex == 4)
            {
                _obstaclesTileMap.SetTile(new Vector3Int(nextSegmentXPos, -3, 0), null);
            }
            
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
        currentSegmentXPos = startXPos;
        levelEntered = false;
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
        
        

        //var levelTrigger = Instantiate(prefabLevelTrigger, new Vector3(startXPos + segmentWidth-2, -1.85f, 0), Quaternion.identity);
        LevelIndex++;
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
        if(levelEntered == true)
        {
            if (CurrentEnemeyCount <= 0)
            {
                _playerReference.transform.parent.GetComponent<BasicGameLogic>().BeginNextLevel();
            }
        }

        

        leftBorderWall.transform.position = new Vector3(leftBorderWall.transform.position.x+1.1f*Time.deltaTime, leftBorderWall.transform.position.y, leftBorderWall.transform.position.z);
        
        if(levelEntered == false)
        {
            if (_playerReference.GetComponentInChildren<PlayerMovement>().gameObject.transform.position.x >= currentSegmentXPos + 1)
            {
                _obstaclesTileMap.SetTile(new Vector3Int(currentSegmentXPos, -3, 0), tileCloudObstacle);
                levelEntered = true;
                int enemyCount = Random.Range(1, 5);
                for (int i = 0; i < enemyCount; i++)
                {
                    var enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], new Vector3(Random.Range(currentSegmentXPos, nextSegmentXPos), Random.Range(-0.82f, -3.5f), 0), Quaternion.identity);
                    CurrentEnemeyCount += 1;
                }
            }
        }

        
    }
}
