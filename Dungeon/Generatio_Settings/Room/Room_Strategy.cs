using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Room_Strategy : ScriptableObject
{
    public abstract Room GenerateRoom(Dungeon_Settings settings, int rLength, int dir, Room prvRoom, bool closed, List<Room> rooms, int index);
}
