using System.Diagnostics;
using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuController : MonoBehaviour
{
    // Start is called before the first frame update
  public static bool isGamePaused = false;
  public GameObject pauseMenuUI;

  void Update(){

   if(Input.GetKeyDown(KeyCode.Escape))
   {
       if(isGamePaused)
       {
           Resume();
       }
       else 
       {
           Pause();
       }
   }

  }


  public void Resume()
  {
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    isGamePaused = false;
  }

  void Pause()
  {
      pauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      isGamePaused = true;
      //if(isGamePaused==false)


  }


public void LoadMenu()
{
 SceneManager.LoadScene("MenuScene");
  Time.timeScale = 1f;
    isGamePaused = false;
}


public void QuitGame()
{
UnityEngine.Debug.Log("Quit Game");
}


}
