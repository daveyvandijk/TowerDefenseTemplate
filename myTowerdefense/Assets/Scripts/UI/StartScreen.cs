using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
   public void GoToStartScreen()
    {
        SceneManager.LoadScene("startscreen");
        Debug.Log("ga naar start screen");
    }
}
