using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaracterLayout : MonoBehaviour
{
    public Vector3 test;
    GameObject currentPlayerLayout;
    CharacterSwitcher characterSwitcher;
    GameObject currentCharacter = null;
    public Camera cam;
    private string characterName;
    // Start is called before the first frame update
    void Start()
    {
        characterSwitcher = GameObject.FindGameObjectWithTag("SwitchSystem").GetComponent<CharacterSwitcher>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentCharacter != null)
        {
            currentCharacter.transform.position = new Vector3(cam.transform.position.x - test.x,cam.transform.position.y - test.y, test.z);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentCharacter != null)
            {
                 Destroy(currentCharacter);
                 currentCharacter = null;
            }
            currentCharacter = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            currentCharacter.AddComponent<Renderer>();
            currentCharacter.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (currentCharacter != null)
            {
                Destroy(currentCharacter);
                currentCharacter = null;
            }
            currentCharacter = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            currentCharacter.transform.position = cam.transform.position;
            currentCharacter.AddComponent<Renderer>();
            currentCharacter.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (currentCharacter != null)
            {
                Destroy(currentCharacter);
                currentCharacter = null;
            }
            currentCharacter = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            currentCharacter.transform.position = cam.transform.position;
            currentCharacter.AddComponent<Renderer>();
            currentCharacter.GetComponent<Renderer>().material.color = Color.red;
            currentCharacter.GetComponent<Renderer>().shadowCastingMode = 0;
        }
    }
}
