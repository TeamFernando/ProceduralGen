using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GenerationLogic : MonoBehaviour
{
    // Generate grid
    // Size of each tile
    // tile x and tile y

    [SerializeField] private float tileSize;
    [SerializeField] private int maxTileX, maxTileY;

    [SerializedField] private int depthToSpawnBossRoom = 4;

    

    
    


    [ContextMenu("GenerateRoom")]
    void Start()
    {
        RoomData data = new RoomData();
        data.sizeX = 5;
        data.sizeY = 5;
        RoomFactory.GenerateRoom(data);
    }

    public RoomData ProcedurallyGenerateRoomData(int depth)
    {
        flat randomVal = Random.Range(0f,1f)
        RoomData data = new RoomData();
        //Testing Purposes
        data.sizeX = 5;
        data.sizeY = 5;
        data.type = RoomType.Regular;
        if (depth == 0)
        {
            data.type = RoomData.Starting;
        }
        if (depth >= depthToSpawnBossRoom && randomVal >= .6f )
        {
            data.type = RoomType.Boss;
        }
    
        return data;
    }

    void GenerateLevel(int depth)
    {
        LevelTree tree = new LevelTree();
        
    }

    
}

public struct Node
{
    LinkedList<Node> _children;
    GameObject Room;

}

public class LevelTree
{
    Node _root;

    

}

public class LevelData
{
    int a;
}


public static class RoomFactory
{
    public static GameObject GenerateRoom(RoomData data)
    { 
        var image = Resources.Load<Texture2D>("Sprites/Tilemap/tile033");
        GameObject room = new("Room");
        
        for (int x = 0 ; x < data.sizeX; x++)
        {
            for (int y = 0 ; y < data.sizeY; y++)
            {
                var tile = new GameObject($"Game Object: {x} {y}");

                tile.transform.parent = room.transform;

                tile.transform.position = new Vector3(x - data.sizeX/2, y - data.sizeY/2, 0);

                var SR = tile.AddComponent<SpriteRenderer>();
                SR.sprite = Sprite.Create(image, new Rect(0, 0, 256, 256), new Vector2(0.5f, 0.5f), 256);

                SR.color = data.type switch
                {
                    RoomType.Starting => Color.green,
                    RoomType.Regular => Color.orange,
                    RoomType.Boss => Color.red,
                    _ => Colour.black,
                };
            }
        }

        return room;
    }
    
    /// <summary>
    /// Generate a list of rooms.
    /// </summary>
    public static List<GameObject> GenerateLevel(LevelData data)
    {
        return new();
    }
}
