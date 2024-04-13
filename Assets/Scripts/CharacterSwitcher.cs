using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    GameObject[] characters;
    public string currentPlayer = "none";
    // Start is called before the first frame update
    void Start()
    {
        characters = new GameObject[3];
        characters[0] = GameObject.FindGameObjectWithTag("Jhon");
        characters[1] = GameObject.FindGameObjectWithTag("Claire");
        characters[2] = GameObject.FindGameObjectWithTag("Thomas");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentPlayer = "Jhon";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentPlayer = "Claire";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)){
            currentPlayer = "Thomas";
        }
    }
}
