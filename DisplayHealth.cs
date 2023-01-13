using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    GameObject player;
    public Text health;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        health.text = "health: " + player.GetComponent<Player>().health.ToString();
        //if (player == null) { player = GameObject.Find("DontDestroyOnLoad/Player(Clone)"); }
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "health: " + player.GetComponent<Player>().health.ToString();
    }
}
