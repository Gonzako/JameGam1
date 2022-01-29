using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

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

    [SerializeField] TileBase[] eyeCandy;

    [SerializeField] GameObject _playerReference;

    [SerializeField] GameObject prefabLevelTrigger;

    [SerializeField] GameObject leftBorderWall;

    public int currentSegmentXPos = 0;

    public int nextSegmentXPos = 0;

    public bool levelEntered = false;

    public int CurrentEnemeyCount = 0;

    public int LayerIndex = 0;

    public Text layerInfo;


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

    public GameObject BOSS;

    private void OnDisable()
    {
        BasicGameLogic.OnLevelEnter -= OnEnterLevel;
    }

    private void OnEnterLevel()
    {
        // generate level

        if (LevelIndex == 4)
        {
            _obstaclesTileMap.SetTile(new Vector3Int(nextSegmentXPos, -3, 0), null);
            GenerateBossRoom(nextSegmentXPos);
        }
        else if (LevelIndex > 5)
        {
            LevelIndex = 0;
            DeleteAllTiles();
            _playerReference.GetComponentInChildren<PlayerMovement>().gameObject.transform.position = new Vector3(0, -2, 0);
            GenerateWorldStart();
            GenerateNextSegment(10);
            leftBorderWall.transform.position = new Vector3(-25f, -1.75f, 0);
            LayerIndex++;
        }
        else
        {
            _obstaclesTileMap.SetTile(new Vector3Int(nextSegmentXPos, -3, 0), null);
            GenerateNextSegment(nextSegmentXPos);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        BasicGameLogic.OnLevelEnter += OnEnterLevel;


        // generate simple room
        Vector3Int roomStartPosition = new Vector3Int(-9, 0, 0);
        Vector3Int roomEndPosition = new Vector3Int(25, -7, 0);

        _baseGroundTileMap.DeleteCells(roomStartPosition, roomEndPosition);
        _walkableObjectsTileMap.DeleteCells(roomStartPosition, roomEndPosition);
        _obstaclesTileMap.DeleteCells(roomStartPosition, roomEndPosition);

        GenerateWorldStart();

        GenerateNextSegment(10);

    }

    void GenerateBossRoom(int startXPos)
    {
        levelEntered = false;
        int segmentWidth = 25;

        currentSegmentXPos = startXPos;
        levelEntered = false;
        nextSegmentXPos = startXPos + segmentWidth - 1;


        for (int y = 0; y > -6; y--)
        {
            for(int x = currentSegmentXPos; x < currentSegmentXPos+segmentWidth; x++)
            {
                Vector3Int currentTilePos = new Vector3Int(x, y, 0);
                if (y == 0)
                {
                    _obstaclesTileMap.SetTile(currentTilePos, seamTileGround);
                }
                else
                {
                    _baseGroundTileMap.SetTile(currentTilePos, baseTileGround);
                    int random = Random.Range(0, 100);
                    if (random >= 40)
                    {
                        _walkableObjectsTileMap.SetTile(currentTilePos, eyeCandy[Random.Range(0, eyeCandy.Length)]);
                    }


                }
                if (x == currentSegmentXPos && y != 0 && y != -3) _obstaclesTileMap.SetTile(currentTilePos, tileCloudObstacle);

                if (y == -5) _obstaclesTileMap.SetTile(currentTilePos, tileCloudObstacle);

                if (x == currentSegmentXPos + segmentWidth - 1 && y != 0) _obstaclesTileMap.SetTile(currentTilePos, tileCloudObstacle);
            }
        }
    }

    void GenerateNextSegment(int startXPos)
    {
        currentSegmentXPos = startXPos;
        levelEntered = false;
        int segmentWidth = Random.Range(15, 30);

        nextSegmentXPos = startXPos + segmentWidth - 1;
        //Debug.Log(nextSegmentXPos);

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
                        else
                        {
                            random = Random.Range(0, 100);
                            if(random >= 90)
                            {
                                _walkableObjectsTileMap.SetTile(currentTilePos, eyeCandy[Random.Range(0, eyeCandy.Length)]);
                            }
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
                if(GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().isPlaying == false)
                {
                    GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().Play();
                    GameObject.FindGameObjectWithTag("BOSSBGM").GetComponent<AudioSource>().Stop();
                }
                _playerReference.transform.parent.GetComponent<BasicGameLogic>().BeginNextLevel();
            }
        }

        layerInfo.text = "Level: " + LevelIndex + " / Layer: " + LayerIndex;

        if(levelEntered == false)
        {
            leftBorderWall.transform.position = new Vector3(leftBorderWall.transform.position.x + 2.2f * Time.deltaTime, leftBorderWall.transform.position.y, leftBorderWall.transform.position.z);

        }

        if (levelEntered == false)
        {
            if (_playerReference.GetComponentInChildren<PlayerMovement>().gameObject.transform.position.x >= currentSegmentXPos + 1)
            {
                LevelIndex++;
                _obstaclesTileMap.SetTile(new Vector3Int(currentSegmentXPos, -3, 0), tileCloudObstacle);
                levelEntered = true;

                if(LevelIndex < 5)
                {
                    int enemyCount = Random.Range(1+LevelIndex+LayerIndex, 5+LevelIndex+LayerIndex);
                    for (int i = 0; i < enemyCount; i++)
                    {

                        // look for possible position => dont spawn inside obstacles

                        bool foundPosition = false;
                        Vector3Int newEnemyPos = new Vector3Int(Random.Range(currentSegmentXPos + 2, nextSegmentXPos - 2), (int)Random.Range(-1, -2.5f), 0);
                        while (foundPosition == false)
                        {

                            var cellPos = _obstaclesTileMap.WorldToCell(newEnemyPos);
                            if(_obstaclesTileMap.GetTile(cellPos) == null)
                            {
                                foundPosition = true;
                                break;
                            }
                            newEnemyPos = new Vector3Int(Random.Range(currentSegmentXPos + 2, nextSegmentXPos - 2), (int)Random.Range(-1, -2.5f), 0);
                        }
                        var enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], newEnemyPos, Quaternion.identity);
                        enemy.GetComponentInChildren<EnemyDeathBehaviour>().Health = enemy.GetComponentInChildren<EnemyDeathBehaviour>().Health + LevelIndex*3 + LayerIndex*3;
                        CurrentEnemeyCount += 1;
                    }
                }
                else if(LevelIndex == 5)
                {
                    var boss = Instantiate(BOSS, new Vector3(Random.Range(currentSegmentXPos + 2, nextSegmentXPos - 2), Random.Range(-1, -2.5f), 0), Quaternion.identity);
                    boss.GetComponentInChildren<EnemyDeathBehaviour>().Health = boss.GetComponentInChildren<EnemyDeathBehaviour>().Health + LevelIndex*3 + LayerIndex*3;
                    GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().Stop();
                    GameObject.FindGameObjectWithTag("BOSSBGM").GetComponent<AudioSource>().Play();
                    CurrentEnemeyCount += 7;
                }
            }
        }

        
    }
}
