using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentLogic : MonoBehaviour
{
    private bool setTimer = false;
    public float time = 2f;
    private float originalTime;
    private GameObject shoot;
    private Vector3 direction;
    private float force;
    private Color shootColor;
    private GameObject shotcun = null;
    // Start is called before the first frame update
    void Start()
    {
        originalTime = time;
        shotcun = GameObject.FindGameObjectWithTag("ShotCun");
        shootColor = GetComponent<Renderer>().material.color;
    }

    private void Update()
    {
        if (time < 0 && setTimer == false)
        {
            setTimer = true;
            time = originalTime;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (setTimer == true)
        {
            force = Random.Range(10f, 30f);
            direction = new Vector3(Random.Range(0, 1f), Random.Range(0, 1f), 0);
            transform.rotation = Quaternion.LookRotation(direction);
            shoot = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            shoot.transform.position = shotcun.transform.position;
            shoot.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            shoot.AddComponent<Rigidbody>();
            shoot.AddComponent<ShootLogic>();
            shoot.GetComponent<Renderer>().material.color = shootColor;
            shoot.GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);
            setTimer = false;

        }
    }
}
