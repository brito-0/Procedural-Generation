using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rooms_Strategy : ScriptableObject
{
    public abstract Room[] GenerateRooms(Dungeon_Settings settings, int rLenght, int dir);
}
