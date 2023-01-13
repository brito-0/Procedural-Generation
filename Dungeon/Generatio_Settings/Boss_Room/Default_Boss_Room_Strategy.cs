using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dungeon_Settings/Boss_Room_Settings")]
public class Default_Boss_Room_Strategy : Boss_Room_Strategy
{
    public override Boss_Room GenerateBossRoom(Dungeon_Settings settings, Room[] rooms) 
    {
        Vector2 cPos = rooms[rooms.Length - 1].GetPos;
        Vector2 bPos = rooms[rooms.Length - 1].GetPos;
        Vector2 bossPos = rooms[rooms.Length - 1].GetPos;
        Quaternion qC = Quaternion.Euler(0, 0, 0);
        Quaternion qBR = Quaternion.Euler(0, 0, 0);

        switch (rooms[rooms.Length - 1].GetPrvDir)
        {
            case 0:
                cPos.y += 10;
                bPos.y += 22;
                qC = Quaternion.Euler(0, 0, 0);
                qBR = Quaternion.Euler(0, 0, 0);
                bossPos.y = bPos.y + 1;
                break;
            case 1:
                cPos.y -= 10;
                bPos.y -= 22;
                qC = Quaternion.Euler(0, 0, 0);
                qBR = Quaternion.Euler(0, 0, 180);
                bossPos.y = bPos.y - 1;
                break;
            case 2:
                cPos.x += 10;
                bPos.x += 22;
                qC = Quaternion.Euler(0, 0, 90);
                qBR = Quaternion.Euler(0, 0, -90);
                bossPos.x = bPos.x + 1;
                break;
            case 3:
                cPos.x -= 10;
                bPos.x -= 22;
                qC = Quaternion.Euler(0, 0, 90);
                qBR = Quaternion.Euler(0, 0, 90);
                bossPos.x = bPos.x - 1;
                break;
        }
        rooms[rooms.Length - 1].Dir[rooms[rooms.Length - 1].GetPrvDir] = true;
        return new Boss_Room(cPos, bPos, bossPos, qC, qBR/*, rooms[rooms.Length - 1].GetPrvDir, rooms[rooms.Length - 1]*/);
    }
}
