using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    public GameObject[] players;
    public float cameraHeight;
    public float cameraDeep;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController properties;
        for (int i = 0; i < players.Length; i++)
        {
            properties = players[i].GetComponent<PlayerController>();
            if (properties.isPlayable)
            {
                transform.position = new Vector3(players[i].transform.position.x, players[i].transform.position.y + cameraHeight, cameraDeep);
            }
        }
    }
}
