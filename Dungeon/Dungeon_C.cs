using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon_C : MonoBehaviour
{
    //[Header("Rooms")]

    public Transform[] Rooms;
    public Transform corridor;
    public Transform bossRoom;
    public GameObject enemyPrefab;
    public GameObject bossPrefab;
    private string SRoom;
    Transform dunFolder;

    private GameObject player;
    public float pTHealth;
    public float pCHealth;

    //[Header("---------------")]
    //public Transform[] RTop;
    //public Transform[] RBot;
    //public Transform[] RRight;
    //public Transform[] RLeft;
    //public Transform REntrance;
    //public Transform[] RExit;

    Vector2 cPos;
    //int lcounter;
    bool first = true;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        pTHealth = player.GetComponent<Player>().getMaxHealth();
        pCHealth = player.GetComponent<Player>().getHealth();
    }

    public void Create(Dungeon dun)
    {
        
        //PlayerCurHealth();

        dunFolder = new GameObject("Dungeon").transform;
        CreateRooms(dun.GetEntryR, 0);
        //
        Debug.Log(" -------------------------------------------------- ");
        //
        for (int i = 1; i < dun.GetTRooms.Length; i++)
        {
            if (dun.GetTRooms[i] != null /*&& dun.GetTRooms[i].GetPos.x != 999*/)
            {

                //
                Debug.Log(dun.GetTRooms[i].GetPos + "," + dun.GetTRooms[i].GetDir[0] + "," + dun.GetTRooms[i].GetDir[1] + "," + dun.GetTRooms[i].GetDir[2] + "," + dun.GetTRooms[i].GetDir[3]);
                //

                CreateRooms(dun.GetTRooms[i], i);
            }
        }
        //
        Debug.Log(" -------------------------------------------------- ");
        //
        CreateBossRoom(dun.GetBossR);
    }

    private void CreateRooms(Room room, int i)
    {
        SRoom = "";
        Transform roomFolder = new GameObject("Room"+(i)).transform;
        roomFolder.SetParent(dunFolder);
        //cPos.x = room.GetPos.x;
        //cPos.y = room.GetPos.y;
        cPos = room.GetPos;
        foreach(bool b in room.Dir)
        {
            if (b)
            {
                SRoom += "1";
            }
            else
            {
                SRoom += "0";
            }
        }
        Transform roomP = FindRoom(Rooms, SRoom);
        PlaceRoom(cPos, roomFolder, roomP);
        PlaceEnemies(cPos, roomFolder, room);
    }
    
    private void PlaceRoom(Vector2 cPos, Transform roomFolder, Transform roomP)
    {
        Transform r = Instantiate(roomP, roomFolder.TransformPoint(cPos), Quaternion.Euler(0, 0, 0));
        r.SetParent(roomFolder);
    }


    private Transform FindRoom(Transform[] rooms, string name)
    {
        foreach (Transform r in rooms)
        {
            if (r.name == name)
            {
                return r;
            }
        }
        return Rooms[0];
    }

    // add a way to check player health
    void PlaceEnemies(Vector2 cPos, Transform roomFolder, Room room)
    {
        if (enemyPrefab != null)
        {
            if (room.GetType != RType.Empty)
            {
                float rand = Random.value;
                int eNumber;
                int eDis;

                if (pCHealth > pTHealth / 2)
                {
                    eDis = 3;
                    if (rand <= .2) { eNumber = 1; }
                    else if (rand >= .6) { eNumber = 3; }
                    else { eNumber = 2; }
                }
                else 
                {
                    eDis = 2;
                    if (rand <= .4) { eNumber = 1; }
                    else if (rand >= .9) { eNumber = 3; }
                    else { eNumber = 2; }
                }

                //int n = Random.Range(1, 4);
                Vector2[] enemyPos = new Vector2[eNumber];
                bool bCheck = true;
                while (bCheck)
                {
                    for (int i = 0; i < eNumber; i++)
                    {
                        enemyPos[i].x = (int)Random.Range(cPos.x - eDis, cPos.x + eDis);
                        enemyPos[i].y = (int)Random.Range(cPos.y - eDis, cPos.y + eDis);
                        //if (enemyPos.Length == n)
                        //{
                            
                        //}
                    }

                    switch (eNumber)
                    {
                        case 1:
                            bCheck = false;
                            break;
                        case 2:
                            if (enemyPos[0] != enemyPos[1])
                            {
                                bCheck = false;
                            }
                            break;
                        case 3:
                            if (enemyPos[0] != enemyPos[1] && enemyPos[0] != enemyPos[2] && enemyPos[1] != enemyPos[2])
                            {
                                bCheck = false;
                            }
                            break;
                    }

                }
                foreach (Vector2 v in enemyPos)
                {
                    GameObject e = Instantiate(enemyPrefab, v, Quaternion.identity);
                    e.transform.SetParent(roomFolder);
                }
            }
        }
        else
        {
            Debug.LogError(" enemy prefab not given ");
        }
    }

    private void CreateBossRoom(Boss_Room bossR)
    {
        Transform bossRoomFolder = new GameObject("Boss Room").transform;
        bossRoomFolder.SetParent(dunFolder);
        Transform bRCorridor = corridor;
        Transform bRoom = bossRoom;
        PlaceBossRoom(bossR.GetcPos, bossR.GetbRPos, bossR.GetBossPos, bossR.GetCorridorRot, bossR.GetBRoomRot,bossRoomFolder, bRCorridor, bRoom);
    }

    private void PlaceBossRoom(Vector2 coPos, Vector2 bRPos, Vector2 bossPos, Quaternion qC, Quaternion qBR, Transform bossRoomFolder, Transform corridor, Transform bRoom)
    {
        Transform c = Instantiate(corridor, bossRoomFolder.TransformPoint(coPos), qC);
        c.SetParent(bossRoomFolder);
        Transform bR = Instantiate(bRoom, bossRoomFolder.TransformPoint(bRPos), qBR);
        bR.SetParent(bossRoomFolder);
        GameObject b = Instantiate(bossPrefab, bossPos, Quaternion.identity);
        b.transform.SetParent(bossRoomFolder);
    }

    //private void PlayerCurHealth() 
    //{
    //    pTHealth = GetComponent<Player>().maxHealth;
    //    //pCHealth = GetComponent<Player>().health;
    //    pCHealth = 15;
    //}
}
