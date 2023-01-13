using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dungeon_Settings/Rooms_Settings")]
public class Default_Rooms_Strategy : Rooms_Strategy
{
    //int lengthC = 0;
    //bool lReached = false;
    //bool first = true;
    int bcount = 0;
    bool closed = false;

    public override Room[] GenerateRooms(Dungeon_Settings settings, int rLenght, int dir)
    {
        int index = -1;
        int ind = 0;
        //bool closed = false;
        List<Room> rooms = new List<Room>();

        rooms.Add(new Room(new Vector2(0, 0), RType.Empty, true, true, true, true));

        // if a recently added room has bounds.x set to 999 delete room go to the previous room and replace the appropriate direction with false

        //return new Room[] { settings.roomStrategy.GenerateRoom(settings, settings.GetLength, dir, index, closed, rooms) };

        // generate new rooms until the length is reached

        // generate top rooms until the length is reached the bottom rooms ...

        //GenRoom(rooms, settings, rLenght, index, ind/*, closed*/);

        GenAllRooms(rooms, settings, rLenght, index, ind/*, closed*/);
        //settings.bossRoomStrategy.GenerateBossRoom(settings, rooms[rooms.Count - 1], rooms, index);
        //rooms = RemoveCollision(rooms);
        return rooms.ToArray();
    }

    //private void GenRoom(List<Room> rooms, Dungeon_Settings settings, int rLength, int index, int ind /*int dir, bool closed*/)
    //{

    //    //Debug.Log("1.closed: " + closed);

    //    // fix closed

    //    bcount = 0;
    //    index++;
    //    if (ind >= (rLength - 4)) 
    //    { 
    //        closed = true;
    //    }
    //    else
    //    {
    //        closed = false;
    //    }

    //    Debug.Log("ind: " + ind);
    //    Debug.Log("index: " + index);


    //    //Debug.Log("2.closed: " + closed);

    //    //if (first)
    //    //{
    //    //    rooms.Add(settings.roomStrategy.GenerateRoom(settings, settings.GetLength, dir, index, closed, rooms));
    //    //    index++;
    //    //}

    //    // make it so it only allows rooms with more than one opening

    //    foreach (bool b in rooms[index].GetDir)
    //    {
    //        if (b) { bcount++; }
    //    }

    //    Debug.Log("dir length: " + rooms[index].GetDir.Length);

    //    //for(int b = 0; b < rooms[index].GetDir.Length - 1; b++)
    //    //{
    //    //    if (rooms[index].GetDir[b]) { bcount++; }
    //    //}

    //    Debug.Log("bcount: " + bcount);

    //    if (bcount > 1 || rooms[index].GetType != RType.End)
    //    {
    //        if (rooms[index].Dir[0] == true)
    //        {
    //            ind++;
    //            rooms.Add(settings.roomStrategy.GenerateRoom(settings, settings.GetLength, 0, rooms[index], closed, rooms));

    //            //if (rooms[rooms.Count - 1].GetPos.x == 999) { rooms = RemoveCollision(rooms, rooms.Count - 1); }
    //            //else { GenRoom(rooms, settings, rLength, index, ind/*, closed*/); }

    //            // figure out the recursion

    //            GenRoom(rooms, settings, rLength, index, ind/*, closed*/);
    //        }
    //        if (rooms[index].Dir[1] == true)
    //        {
    //            ind++;
    //            rooms.Add(settings.roomStrategy.GenerateRoom(settings, settings.GetLength, 1, rooms[index], closed, rooms));

    //            //if (rooms[rooms.Count - 1].GetPos.x == 999) { rooms = RemoveCollision(rooms, rooms.Count - 1); }
    //            //else { GenRoom(rooms, settings, rLength, index, ind/*, closed*/); }

    //            // figure out the recursion

    //            GenRoom(rooms, settings, rLength, index, ind/*, closed*/);
    //        }
    //        if (rooms[index].Dir[2] == true)
    //        {
    //            ind++;
    //            rooms.Add(settings.roomStrategy.GenerateRoom(settings, settings.GetLength, 2, rooms[index], closed, rooms));

    //            //if (rooms[rooms.Count - 1].GetPos.x == 999) { rooms = RemoveCollision(rooms, rooms.Count - 1); }
    //            //else { GenRoom(rooms, settings, rLength, index, ind/*, closed*/); }

    //            // figure out the recursion

    //            GenRoom(rooms, settings, rLength, index, ind/*, closed*/);
    //        }
    //        if (rooms[index].Dir[3] == true)
    //        {
    //            ind++;
    //            rooms.Add(settings.roomStrategy.GenerateRoom(settings, settings.GetLength, 3, rooms[index], closed, rooms));

    //            //if (rooms[rooms.Count - 1].GetPos.x == 999) { rooms = RemoveCollision(rooms, rooms.Count - 1); }
    //            //else { GenRoom(rooms, settings, rLength, index, ind/*, closed*/); }

    //            // figure out the recursion

    //            GenRoom(rooms, settings, rLength, index, ind/*, closed*/);
    //        }
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}

    private void GenAllRooms(List<Room> rooms, Dungeon_Settings settings, int rLength, int index, int ind)
    {
        bcount = 0;
        index++;
        if (ind > rLength /*(rLength/2)*/)
        {
            closed = true;
        }
        else
        {
            closed = false;
        }
        //Debug.Log("ind: " + ind);
        //Debug.Log("index: " + index);
        foreach (bool b in rooms[index].GetDir)
        {
            if (b) { bcount++; }
        }
        //Debug.Log("bcount: " + bcount);
        if (bcount > 1 || rooms[index].GetType != RType.End)
        {
            if (rooms[index].Dir[0] == true)
            {
                ind++;
                rooms.Add(settings.roomStrategy.GenerateRoom(settings, settings.GetLength, 0, rooms[index], closed, rooms, index));
                rooms = RemoveCollision(rooms, rooms.Count - 1);
            }
            if (rooms[index].Dir[1] == true)
            {
                ind++;
                rooms.Add(settings.roomStrategy.GenerateRoom(settings, settings.GetLength, 1, rooms[index], closed, rooms, index));
                rooms = RemoveCollision(rooms, rooms.Count - 1);
            }
            if (rooms[index].Dir[2] == true)
            {
                ind++;
                rooms.Add(settings.roomStrategy.GenerateRoom(settings, settings.GetLength, 2, rooms[index], closed, rooms, index));
                rooms = RemoveCollision(rooms, rooms.Count - 1);
            }
            if (rooms[index].Dir[3] == true)
            {
                ind++;
                rooms.Add(settings.roomStrategy.GenerateRoom(settings, settings.GetLength, 3, rooms[index], closed, rooms, index));
                rooms = RemoveCollision(rooms, rooms.Count - 1);
            }
            GenAllRooms(rooms, settings, rLength, index, ind);
        }
        else
        {
            return;
        }
    }

    private List<Room> RemoveCollision(List<Room> rooms, int index)
    {
        if (rooms[index].GetPos.x == 999)
        {
            rooms.RemoveAt(index);
        }
        return rooms;
    }
}
