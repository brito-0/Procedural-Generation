using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    private Vector2 zero = new Vector2(0,0);
    private GameObject player;
    private GameObject endScreen;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        endScreen = GameObject.FindWithTag("EndScreen");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DontDestroyOnLoad(collision.gameObject);
            //DontDestroyOnLoad(endScreen);
            SceneManager.LoadScene("NextScene");
            collision.transform.position = zero;
            //if (player.GetComponent<Player>().health < player.GetComponent<Player>().maxHealth) { player.GetComponent<Player>().health += 1f; }
            //Application.LoadLevel("NextScene");
            endScreen.GetComponent<EndScreen>().incCounter();
        }
    }
}
