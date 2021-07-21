using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StopMenu : MonoBehaviour
{
    public GameObject MenuButtons;
    public GameObject buttonsMenu;
    public GameObject buttonsExit;
    public GameObject Savebuttons;
    public GameObject destroyedPlayer;
    bool paused = false;
    public void Click()
    {
        
            Time.timeScale = 0;
            paused = true;
            MenuButtons.SetActive(true);
        
    }
    public void ShowExitButtons()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(true);
    }
    public void DestroyedPlayer()
    {
        MenuButtons.SetActive(true);
        buttonsMenu.SetActive(false);
        destroyedPlayer.SetActive(true);
    }

    public void BackInMenu()
    {
        buttonsMenu.SetActive(true);
        buttonsExit.SetActive(false);
    }
    public void ShowSaveButtons()
    {
       
        buttonsExit.SetActive(false);
        Savebuttons.SetActive(true);
       
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        paused = false;        
        MenuButtons.SetActive(false);
    }
    public void LoadMainMenu()
    {       
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
        paused = false;
    }
    public void LoadScoreTable()
    {
        SceneManager.LoadScene("Score");
        Time.timeScale = 1;
        paused = false;
    }
}
