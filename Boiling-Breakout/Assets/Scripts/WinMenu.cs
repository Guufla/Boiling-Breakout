using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    //return button for win and lose scenes
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
