using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Generator
{

    // public Dungeon(int rLength, Room entryR, Room[] Trooms, Room[] Brooms, Room[] Rrooms, Room[] Lrooms)

    public static Dungeon Generate(Dungeon_Settings settings)
    {
        Room[] rooms = settings.roomsStrategy.GenerateRooms(settings, settings.GetLength, 0);
        //var bossRoom = settings.bossRoomStrategy.GenerateBossRoom(settings, rooms);
        return new Dungeon(
            GenerateRLenght(settings), 
            GenerateEntryR(settings), 
            rooms,
            settings.bossRoomStrategy.GenerateBossRoom(settings, rooms)
            //bossRoom
            //settings.roomsStrategy.GenerateRooms(settings, settings.GetLength, 0), // top rooms
            //settings.bossRoomStrategy.GenerateBossRoom(settings, ro)
            //settings.roomsStrategy.GenerateRooms(settings, settings.GetLength, 1), // bottom rooms
            //settings.roomsStrategy.GenerateRooms(settings, settings.GetLength, 2), // rigth rooms
            //settings.roomsStrategy.GenerateRooms(settings, settings.GetLength, 3)  // left rooms
            );
    }

    static int GenerateRLenght(Dungeon_Settings settings)
    {
        return settings.GetLength;
    }

    static Room GenerateEntryR(Dungeon_Settings settings)
    {
        return new Room(new Vector2(0, 0), RType.Empty, true, true, true, true);
    }

    //static Room[] GenerateRooms(Dungeon_Settings settings, int rLenght, int dir)
    //{
    //    return new Room[] { settings.roomStrategy.GenerateRoom(settings, settings.GetLength, dir) };
    //}

    //static Room[] GenerateBRooms(Dungeon_Settings settings)
    //{
    //    return new Room[] { settings.roomStrategy.GenerateRoom(settings, settings.GetLength) };
    //}

    //static Room[] GenerateRRooms(Dungeon_Settings settings)
    //{
    //    return new Room[] { settings.roomStrategy.GenerateRoom(settings, settings.GetLength) };
    //}

    //static Room[] GenerateLRooms(Dungeon_Settings settings)
    //{
    //    return new Room[] { settings.roomStrategy.GenerateRoom(settings, settings.GetLength) };
    //}

    //static Room GenerateRoom(Dungeon_Settings settings, int rLenght)
    //{
    //    return new Room(new Vector2(10, 0), RType.Normal, false, false, true, true);
    //}
}





//public static Dungeon Generate()
//{
//    return new Dungeon(
//        4,
//        new Room(new Vector2(0, 0), RType.Empty, true, true, true, true),
//        new Room[] {
//                new Room(new Vector2(10,0), RType.Normal, false, false, true, true),
//                new Room(new Vector2(0,10), RType.Normal, true, true, true, false)
//        },
//        new Room[] {
//                new Room(new Vector2(10,0), RType.Normal, false, false, true, true),
//                new Room(new Vector2(0,10), RType.Normal, true, true, true, false)
//        },
//        new Room[] {
//                new Room(new Vector2(10,0), RType.Normal, false, false, true, true),
//                new Room(new Vector2(0,10), RType.Normal, true, true, true, false)
//        },
//        new Room[] {
//                new Room(new Vector2(10,0), RType.Normal, false, false, true, true),
//                new Room(new Vector2(0,10), RType.Normal, true, true, true, false)
//        }
//        );
//}

