using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutBack : MonoBehaviour {

    public bool isBack;

    void onMouseUp()
    {
        if (isBack)
        {
            SceneManager.LoadScene(0);
            //Application.LoadLevel(0);
        }

    }
}
