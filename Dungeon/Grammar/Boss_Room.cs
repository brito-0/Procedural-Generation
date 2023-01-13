using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Room
{
    Vector2 cPos;
    Vector2 bRPos;
    Vector2 bossPos;
    Quaternion corridorRot;
    Quaternion roomRot;
    int prvDir;
    Room prvRoom;
    int prvIndex;

    public Vector2 GetcPos { get => cPos; }
    public Vector2 GetbRPos { get => bRPos; }
    public Vector2 GetBossPos { get => bossPos; }
    public Quaternion GetCorridorRot { get => corridorRot; }
    public Quaternion GetBRoomRot { get => roomRot; }
    public int GetPrvDir { get => prvDir; }
    public Room GetPrvRoom { get => prvRoom; }
    public int GetPrvIndex { get => prvIndex; }
    

    public Boss_Room(Vector2 cPos, Vector2 bRPos, Vector2 bossPos, Quaternion corridorRot, Quaternion roomRot/*, int prvDir, Room prvRoom/*, int prvIndex*/)
    {
        this.cPos = cPos;
        this.bRPos = bRPos;
        this.bossPos = bossPos;
        this.corridorRot = corridorRot;
        this.roomRot = roomRot;
        //this.prvDir = prvDir;
        //this.prvRoom = prvRoom;
        //this.prvIndex = prvIndex;
    }
}
