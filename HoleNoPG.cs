using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoleNoPG : MonoBehaviour
{
    private Vector2 zero = new Vector2(0,0);
    private GameObject player;
    private GameObject endScreen;

    //public GameObject map1;
    //public GameObject map2;

    //private bool mapSwitch;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        endScreen = GameObject.FindWithTag("EndScreen");

        //mapSwitch = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DontDestroyOnLoad(collision.gameObject);
            //DontDestroyOnLoad(endScreen);
            SceneManager.LoadScene("NoPGNext");
            collision.transform.position = zero;
            //if (player.GetComponent<Player>().health < player.GetComponent<Player>().maxHealth) { player.GetComponent<Player>().health += 1f; }
            //Application.LoadLevel("NextScene");
            endScreen.GetComponent<EndScreen>().incCounter();

            //mapSwitch = true ? mapSwitch = false : mapSwitch = true;

            //switch (mapSwitch) {
            //    case (false):
            //        Instantiate(map2, zero, Quaternion.identity);
            //        break;
            //    case (true):
            //        Instantiate(map1, zero, Quaternion.identity);
            //        break;
            //}
        }
    }
}
