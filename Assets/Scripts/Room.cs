using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class RoomData
{
    public int sizeX;
    public int sizeY;
    public RoomType type;
    
    // Decide if rooms should have a door based on their placement alongside other rooms
    public bool hasTopDoor = true;
    public bool hasLeftDoor = true;
    public bool hasRightDoor = true;
    public bool hasBottomDoor = true;
}



public class Room : MonoBehaviour
{
    //List<Tile> _tiles = new();

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

