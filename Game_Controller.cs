using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    bool noDmgFall = false;
    public bool first;
    public GameObject holePrefab;

    //private GameObject endScreen;

    public GameObject boss;
    public Vector2 hPos;
    private bool noBoss = true;
    private bool stop = true;

    public GameObject map1;
    public GameObject map2;
    private bool mapSwitch;
    public bool noPG = false;

    // Start is called before the first frame update
    public void Awake()
    {
        if (first) { Instantiate(playerPrefab, new Vector2(0, 0), Quaternion.identity); }

        if (noPG && map1 != null) 
        { 
            DontDestroyOnLoad(GameObject.FindWithTag("Controller")); 
            mapSwitch = true; 
            Instantiate(map1); }
    }

    private void Start()
    {
        //bossFolder = GameObject.Find("Dungeon").transform;

        //boss = GameObject.FindGameObjectWithTag("EnemyBoss");
        //hPos.position = boss.transform.position;
    }

    private void Update()
    {
        if (boss == null && noBoss) 
        {
            boss = GameObject.FindGameObjectWithTag("EnemyBoss");
            hPos = boss.transform.position;
            noBoss = false;
        }
        if (boss == null && !noBoss && stop) 
        {
            Instantiate(holePrefab, hPos, Quaternion.identity);
            stop = false;
        }
    }

    // check if boss is dead if it is then spawn hole and health

    private void OnLevelWasLoaded(int level)
    {
        if (noPG)
        {
            //mapSwitch = true ? mapSwitch = false : mapSwitch = true;
            if (mapSwitch) { mapSwitch = false; } else { mapSwitch = true; }

            switch (mapSwitch)
            {
                case (false):
                    Instantiate(map2);
                    break;
                case (true):
                    Instantiate(map1);
                    break;
            }

            noBoss = true;
            stop = true;
}
    }
}
