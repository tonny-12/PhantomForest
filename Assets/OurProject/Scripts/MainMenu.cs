using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public bool isStart;
    public bool isAbout;
    public bool isExit;

    void OnMouseUp()
    {
        if(isStart)
        {
            SceneManager.LoadScene(1);
            //Application.LoadLevel(1);
        }

        if(isExit)
        {
            Application.Quit();
        }

        if(isAbout)
        {
            SceneManager.LoadScene(2);
        }
    }
}
