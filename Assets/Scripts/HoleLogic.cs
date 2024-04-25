using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoleLogic : MonoBehaviour
{
    public Camera camera;
    private float time = 3;
    private bool setTimer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (setTimer)
        {
            time -= Time.deltaTime;
        }
        if (time < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        setTimer = true;
        camera.GetComponent<CameraFocus>().enabled = false;
        gameObject.GetComponent<MeshCollider>().enabled = false;
    }
}
