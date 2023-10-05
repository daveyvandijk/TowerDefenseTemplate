using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
   public void GoToStartScreen()
    {
        SceneManager.LoadSceneAsync("startscreen");
        Debug.Log("ga naar start screen");
    }
}
