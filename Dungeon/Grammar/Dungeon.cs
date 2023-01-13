using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon
{
    int rLength;
    Room entryR;
    //Room[] rooms;
    Room[] Trooms;
    //Room[] Brooms;
    //Room[] Lrooms;
    //Room[] Rrooms;
    Boss_Room bossR;
    Stairs_Room stairsR;

    public int GetRLenght { get => rLength; }
    public Room GetEntryR { get => entryR; }
    public Room[] GetTRooms { get => Trooms; }
    //public Room[] GetBRooms { get => Brooms; }
    //public Room[] GetLRooms { get => Lrooms; }
    //public Room[] GetRRooms { get => Rrooms; }
    public Boss_Room GetBossR { get => bossR; }
    public Stairs_Room GetStairsR { get => stairsR; }

    public Dungeon(int rLength, Room entryR, Room[] Trooms/*, Room[] Brooms, Room[] Rrooms, Room[] Lrooms*/)
    {
        this.rLength = rLength;
        this.entryR = entryR;
        this.Trooms = Trooms;
        //this.Brooms = Brooms;
        //this.Rrooms = Rrooms;
        //this.Lrooms = Lrooms;
    }

    public Dungeon (int rLength, Room entryR, Room[] Trooms, Boss_Room bossR/*, Stairs_Room stairsR*/)
    {
        this.rLength = rLength;
        this.entryR = entryR;
        this.Trooms = Trooms;
        //this.Brooms = Brooms;
        //this.Rrooms = Rrooms;
        //this.Lrooms = Lrooms;
        this.bossR = bossR;
        //this.stairsR = stairsR;
    }
}
