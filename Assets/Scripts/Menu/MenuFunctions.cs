using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
   public void CloseGame()
    {
        Application.Quit();
    }

    public void StarGame()
    {
        SceneManager.LoadScene(0);
    }
}
