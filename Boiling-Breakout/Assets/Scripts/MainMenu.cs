using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //make sure to  go in build settings and add game level, win and lose scene, and take notes of index number of scenes and plug in parentheses of load scene functions accordingly

    public void PlayGame ()
       
    {
        SceneManager.LoadScene(1);
    }

    //make sure to get rid of debug log when building final game

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
