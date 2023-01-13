using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dungeon_Settings")]
public class Dungeon_Settings : ScriptableObject
{
    //[Range(1, 10)]
    [Header("minimum number of rooms")]
    [Range(10, 30)]
    public int dungeonLength;
    [Header("generation strategies")]
    public Room_Strategy roomStrategy;
    public Rooms_Strategy roomsStrategy;
    public Boss_Room_Strategy bossRoomStrategy;

    public int GetLength { get => dungeonLength; }
}
