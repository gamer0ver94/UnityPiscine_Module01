using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColorChange : MonoBehaviour
{

    public GameObject[] platform;
    public Material[] colors;
    private string[] mask = new string[3];
    // Start is called before the first frame update
    void Start()
    {
        mask[0] = "RedPlat";
        mask[1] = "BluePlat";
        mask[2] = "YellowPlat";
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnCollisionEnter(Collision collider)
    {
        Vector3 hit = collider.contacts[0].normal;
        float angle = Vector3.Angle(hit, Vector3.up);
        if (Mathf.Approximately(angle, 180))
        {
            for (int i = 0; i < platform.Length; i++)
            {
                for (int j = 0; j < colors.Length; j++)
                {
                    if (collider.collider.GetComponent<Renderer>().material.color == colors[j].color)
                    {
                        platform[i].GetComponent<Renderer>().material.color = colors[j].color;
                        platform[i].gameObject.layer = LayerMask.NameToLayer(mask[j]);
                    }
                }
            }
        }
    }
}
