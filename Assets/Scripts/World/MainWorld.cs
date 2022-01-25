using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MainWorld : MonoBehaviour
{
    [SerializeField] GameObject _playerReference;

    [SerializeField] Tilemap _baseGroundTileMap;
    [SerializeField] Tilemap _walkableObjectsTileMap;
    [SerializeField] Tilemap _obstaclesTileMap;

    [SerializeField] TileBase tileSeamToBackground;
    [SerializeField] TileBase baseTileGround;

    

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

        TileBase tileToCreate = baseTileGround;

        for(int x = -9; x < 25; x++)
        {
            CreateNewDungeonLine(x);
        }

    }

    private void CreateNewDungeonLine(int xPos)
    {
        TileBase tileToCreate = baseTileGround;

        // create new tiles on that x level
        for (int y = 0; y > -7; y--)
        {
            if (y == 0)
            {
                tileToCreate = tileSeamToBackground;
            }
            else
            {
                tileToCreate = baseTileGround;
            }

            _baseGroundTileMap.SetTile(new Vector3Int(xPos, y, 0), tileToCreate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // get player position
        // check for tilepos (convert to playerpos to tilemappos)

        var playerPos = _playerReference.transform.position;

        // check for tiles on the right

        playerPos.x = playerPos.x += 10;

        var tileMapPos = _baseGroundTileMap.WorldToCell(playerPos);

        if(_baseGroundTileMap.GetTile(tileMapPos) == null)
        {
            CreateNewDungeonLine(Mathf.RoundToInt(playerPos.x));
        }


    }
}
