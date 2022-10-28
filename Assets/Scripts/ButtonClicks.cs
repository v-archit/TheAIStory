using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClicks : MonoBehaviour
{

    public void LoadScene(int scene)
    {
        //Load main scene
        //1 -> Main scene
        //0 -> Menu scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);    
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
