using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dungeon_Settings/Room_Settings")]
public class Default_Room_Strategy : Room_Strategy
{
    // check for collision if collision is detected set bounds.x to 999

    // if closed is true only closed rooms will be returned

    // if int dir is 5 return null ???



    public override Room GenerateRoom(Dungeon_Settings settings, int rLength, int dir, Room prvRoom, bool closed, List<Room> rooms, int prvIndex)
    {
        //return new Room(new Vector2(10, 0), RType.Normal, false, false, true, true, dir, prvRoom);
        //return new Room(new Vector2(10, 0), RType.Normal, false, false, false, false, dir, prvRoom);

        // add basic a strategy

        Debug.Log(" ||||| " + closed + " ||||| ");

        //switch (dir)
        //{
        //    case 0:
        //        //if (prvRoom.GetBounds.y == 10) { return new Room(new Vector2(0, 20), RType.Normal, false, false, false, false, dir, prvRoom); }
        //        return new Room(new Vector2(0, 10), RType.Normal, true, false, false, false, dir, prvRoom);
        //        break;
        //    case 1:
        //        //if (prvRoom.GetBounds.y == 10) { return new Room(new Vector2(0, 20), RType.Normal, false, false, false, false, dir, prvRoom); }
        //        return new Room(new Vector2(0, -10), RType.Normal, false, true, false, false, dir, prvRoom);
        //        break;
        //    case 2:
        //        //if (prvRoom.GetBounds.y == 10) { return new Room(new Vector2(0, 20), RType.Normal, false, false, false, false, dir, prvRoom); }
        //        return new Room(new Vector2(10, 0), RType.Normal, false, false, false, false, dir, prvRoom);
        //        break;
        //    case 3:
        //        //if (prvRoom.GetBounds.y == 10) { return new Room(new Vector2(0, 20, 5, 5), RType.Normal, false, false, false, false, dir, prvRoom); }
        //        return new Room(new Vector2(-10, 0, 5, 5), RType.Normal, false, false, false, false, dir, prvRoom);
        //        break;
        //    default:
        //        //if (prvRoom.GetBounds.y == 10) { return new Room(new Vector2(0, 20), RType.Normal, false, false, false, false, dir, prvRoom); }
        //        return new Room(new Vector2(0, 20), RType.Normal, false, false, false, false, dir, prvRoom);
        //        break;
        //}





        int x = 0;
        int y = 0;
        bool[] openDir = new bool[4];
        int rndm = Random.Range(0, 2);
        RectInt compPos;
        RType roomType;

        int colChange;
        //int xPos;
        //int yPos;

        switch (closed)
        {
            case false:

                //if ((bool)(Random.value > .1f))
                //{
                //    roomType = RType.Normal;
                //}
                //else
                //{
                //    roomType = RType.Empty;
                //}

                roomType = RTypeRule(prvRoom);


                //openDir = RandDir(dir, openDir);
                openDir = DirCO(prvRoom, dir, openDir);
                //openDir = DirC(prvRoom, dir, openDir);

                switch (dir)
                {
                    case 0:
                        //openDir[0] = (Random.value > .3f);
                        //openDir[1] = true;
                        //openDir[2] = (Random.value > .7f);
                        //openDir[3] = (Random.value > .7f);

                        x = (int)prvRoom.GetPos.x;
                        y = (int)prvRoom.GetPos.y + 10;
                        break;
                    case 1:
                        //openDir[0] = true;
                        //openDir[1] = (Random.value > .3f);
                        //openDir[2] = (Random.value > .7f);
                        //openDir[3] = (Random.value > .7f);

                        x = (int)prvRoom.GetPos.x;
                        y = (int)prvRoom.GetPos.y - 10;
                        break;
                    case 2:
                        //openDir[0] = (Random.value > .7f);
                        //openDir[1] = (Random.value > .7f);
                        //openDir[2] = (Random.value > .3f);
                        //openDir[3] = true;

                        x = (int)prvRoom.GetPos.x + 10;
                        y = (int)prvRoom.GetPos.y;
                        break;
                    case 3:
                        //openDir[0] = (Random.value > .7f);
                        //openDir[1] = (Random.value > .7f);
                        //openDir[2] = true;
                        //openDir[3] = (Random.value > .3f);

                        x = (int)prvRoom.GetPos.x - 10;
                        y = (int)prvRoom.GetPos.y;
                        break;
                }

                foreach (Room r in rooms)
                {
                    if (x == r.GetPos.x && y == r.GetPos.y)
                    {
                        x = 999;

                        Debug.Log("collision");
                        Debug.Log("x: " + x);
                        Debug.Log("y: " + y);
                        Debug.Log("collision");

                        //return null;
                    }
                }

                return new Room(new Vector2(x, y), roomType, openDir[0], openDir[1], openDir[2], openDir[3], dir, prvRoom, prvIndex);

            case true:
                //for (int i = 0; i < 4; i++)
                //{
                //    if (i == dir)
                //    {
                //        openDir[i] = true;
                //    }
                //    else
                //    {
                //        openDir[i] = false;
                //    }
                //}

                //if ((bool)(Random.value > .1f))
                //{
                //    roomType = RType.Normal;
                //}
                //else
                //{
                //    roomType = RType.Empty;
                //}

                roomType = RType.End;

                switch (dir)
                {
                    case 0:
                        openDir[0] = false;
                        openDir[1] = true;
                        openDir[2] = false;
                        openDir[3] = false;

                        x = (int)prvRoom.GetPos.x;
                        y = (int)prvRoom.GetPos.y + 10;
                        break;
                    case 1:
                        openDir[0] = true;
                        openDir[1] = false;
                        openDir[2] = false;
                        openDir[3] = false;

                        x = (int)prvRoom.GetPos.x;
                        y = (int)prvRoom.GetPos.y - 10;
                        break;
                    case 2:
                        openDir[0] = false;
                        openDir[1] = false;
                        openDir[2] = false;
                        openDir[3] = true;

                        x = (int)prvRoom.GetPos.x + 10;
                        y = (int)prvRoom.GetPos.y;
                        break;
                    case 3:
                        openDir[0] = false;
                        openDir[1] = false;
                        openDir[2] = true;
                        openDir[3] = false;

                        x = (int)prvRoom.GetPos.x - 10;
                        y = (int)prvRoom.GetPos.y;
                        break;
                }

                foreach (Room r in rooms)
                {
                    if (x == r.GetPos.x && y == r.GetPos.y)
                    {
                        x = 999;

                        Debug.Log("collision");
                        Debug.Log("x: " + x);
                        Debug.Log("y: " + y);
                        Debug.Log("collision");

                        //return null;
                    }
                }

                return new Room(new Vector2(x, y), roomType, openDir[0], openDir[1], openDir[2], openDir[3], dir, prvRoom, prvIndex);

            default:
                return new Room(new Vector2(0, 0), RType.Empty, false, false, false, false, dir, prvRoom, prvIndex);

        }






    }

    public RType RTypeRule(Room prvRoom)
    {
        if (prvRoom.GetType == RType.Empty)
        {
            return RType.Normal;
        }
        else
        {
            if ((bool)(Random.value > .1f))
            {
                return RType.Normal;
            }
            else
            {
                return RType.Empty;
            }
        }
    }

    public bool[] RandDir(int dir, bool[] openDir) 
    {
        switch (dir)
        {
            case 0:
                openDir[0] = (Random.value > .3f);
                openDir[1] = true;
                openDir[2] = (Random.value > .7f);
                openDir[3] = (Random.value > .7f);

                break;
            case 1:
                openDir[0] = true;
                openDir[1] = (Random.value > .3f);
                openDir[2] = (Random.value > .7f);
                openDir[3] = (Random.value > .7f);

                break;
            case 2:
                openDir[0] = (Random.value > .7f);
                openDir[1] = (Random.value > .7f);
                openDir[2] = (Random.value > .3f);
                openDir[3] = true;

                break;
            case 3:
                openDir[0] = (Random.value > .7f);
                openDir[1] = (Random.value > .7f);
                openDir[2] = true;
                openDir[3] = (Random.value > .3f);

                break;
        }
        return openDir;
    }

    public bool[] DirC(Room prvRoom, int dir, bool[] openDir) 
    {
        if (prvRoom.Dir[0] && prvRoom.Dir[1] && !prvRoom.Dir[2] && !prvRoom.Dir[3])
        {
            openDir[0] = true;
            openDir[1] = true;
            openDir[2] = false;
            openDir[3] = false;
            return openDir;
        }
        else if (!prvRoom.Dir[0] && !prvRoom.Dir[1] && prvRoom.Dir[2] && prvRoom.Dir[3])
        {
            openDir[0] = false;
            openDir[1] = false;
            openDir[2] = true;
            openDir[3] = true;
            return openDir;
        }
        else 
        {
            return RandDir(dir, openDir);
        }
    }
    public bool[] DirCO(Room prvRoom, int dir, bool[] openDir) 
    {
        if (prvRoom.GetPrvRoom != null)
        {
            if ((prvRoom.Dir[0] && prvRoom.Dir[1] && !prvRoom.Dir[2] && !prvRoom.Dir[3]) && (prvRoom.GetPrvRoom.Dir[0] && prvRoom.GetPrvRoom.Dir[1] && !prvRoom.GetPrvRoom.Dir[2] && !prvRoom.GetPrvRoom.Dir[3]))
            {
                openDir[0] = true;
                openDir[1] = true;
                openDir[2] = true;
                openDir[3] = true;
                return openDir;
            }
            else if ((!prvRoom.Dir[0] && !prvRoom.Dir[1] && prvRoom.Dir[2] && prvRoom.Dir[3]) && (!prvRoom.GetPrvRoom.Dir[0] && !prvRoom.GetPrvRoom.Dir[1] && prvRoom.GetPrvRoom.Dir[2] && prvRoom.GetPrvRoom.Dir[3]))
            {
                openDir[0] = true;
                openDir[1] = true;
                openDir[2] = true;
                openDir[3] = true;
                return openDir;
            }
            else 
            {
                return DirC(prvRoom, dir, openDir);
            }
        }
        else 
        {
            return DirC(prvRoom, dir, openDir);
        }
    }

}
