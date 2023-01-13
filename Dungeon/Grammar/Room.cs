using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    Vector2 pos;
    RType type;
    //RDir dir;
    bool[] dir = new bool[4]; // 0 top    +x
                              // 1 bottom -x
                              // 2 right  +y
                              // 3 left   -y  
    int prvDir;
    Room prvRoom;
    int prvIndex;

    public Vector2 GetPos { get => pos; }
    public RType GetType { get => type; }
    public bool[] Dir { get => dir; set => dir = value; }
    public bool[] GetDir { get => dir; }
    public int GetPrvDir { get => prvDir; }
    public Room GetPrvRoom { get => prvRoom; }
    public int GetPrvIndex { get => prvIndex; }

    public Room(Vector2 pos, RType type, bool dir0, bool dir1, bool dir2, bool dir3)
    {
        this.pos = pos;
        this.type = type;
        dir[0] = dir0;
        dir[1] = dir1;
        dir[2] = dir2;
        dir[3] = dir3;
    }

    public Room(Vector2 pos, RType type, bool dir0, bool dir1, bool dir2, bool dir3, int prvDir, Room prvRoom, int prvIndex) {
        this.pos = pos;
        this.type = type;
        dir[0] = dir0;
        dir[1] = dir1;
        dir[2] = dir2;
        dir[3] = dir3;
        this.prvDir = prvDir;
        this.prvRoom = prvRoom;
        this.prvIndex = prvIndex;
    }
}

public enum RType {
    Empty,  // normal room without enemies
    Normal, // normal sized room
    //Big,    // larger sized room
    End     // normal room with only one door (stops generation in that direction)
}

//public enum RDir
//{
//    Top,    // +y
//    Bottom, // -y
//    Right,  // +x
//    Left    // -x
//}
