using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public GameObject player;
    public GameObject endScreen;
    public Text healthText;
    public Text endText;

    public int counter;


    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        player = GameObject.FindWithTag("Player");
        endScreen = GameObject.FindWithTag("EndScreen");
        endScreen.GetComponent<SpriteRenderer>().enabled = false;
        healthText = GameObject.FindWithTag("HealthText").GetComponent<Text>();
        endText = GameObject.FindWithTag("EndText").GetComponent<Text>();
        endText.gameObject.SetActive(false);

        DontDestroyOnLoad(endScreen);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) 
        {
            healthText.gameObject.SetActive(false);
            endScreen.GetComponent<SpriteRenderer>().enabled = true;
            endText.gameObject.SetActive(true);
            endText.text = "you cleared " + counter + " dungeons";
        }
    }

    public void incCounter() 
    {
        counter++;
    }

    private void OnLevelWasLoaded(int level)
    {
        healthText = GameObject.FindWithTag("HealthText").GetComponent<Text>();
        endText = GameObject.FindWithTag("EndText").GetComponent<Text>();
        endText.gameObject.SetActive(false);
    }
}
