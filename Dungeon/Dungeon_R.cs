using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon_R : MonoBehaviour
{
    public Dungeon_Settings settings;

    // Start is called before the first frame update
    void Start()
    {
        Dungeon d = Generator.Generate(settings);
        GetComponent<Dungeon_C>().Create(d);
    }

}
