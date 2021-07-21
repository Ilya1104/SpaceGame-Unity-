using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject buttonsMenu;
    public GameObject buttonsExit;
    public GameObject rulesPanel;

    //private int startDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowRules()
    {
        rulesPanel.SetActive(true);
        buttonsMenu.SetActive(false);
    }
    public void ShowExitButtons()
    {
      
            buttonsMenu.SetActive(false);
            buttonsExit.SetActive(true);
    }

    public void BackInMenu()
    {
        
            buttonsMenu.SetActive(true);
            buttonsExit.SetActive(false);
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadScoreTable()
    {
        SceneManager.LoadScene("Score");
    }
}
