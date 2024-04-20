using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    // Start is called before the first frame update
    bool red;
    bool yellow;
    bool blue;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        red = GameObject.FindGameObjectWithTag("ExitRed").GetComponent<GamePlayObjective>().validation;
        yellow = GameObject.FindGameObjectWithTag("ExitYellow").GetComponent<GamePlayObjective>().validation;
        blue = GameObject.FindGameObjectWithTag("ExitBlue").GetComponent<GamePlayObjective>().validation;
        if (red && blue && yellow) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
