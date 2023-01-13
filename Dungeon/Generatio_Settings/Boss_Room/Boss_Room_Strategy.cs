using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss_Room_Strategy : ScriptableObject
{
    public abstract Boss_Room GenerateBossRoom(Dungeon_Settings settings, Room[] rooms);
}
