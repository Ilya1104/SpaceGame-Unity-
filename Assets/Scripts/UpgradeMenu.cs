using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public GameObject allButtons;
    public GameObject upgradeShip;
    public GameObject upgradeShot;
    public GameObject bonuses;
    public GameObject mainButtons;
    public GameObject returnFromShip;
    public GameObject returnFromShot;
    public GameObject returnFromBonuses;

    private int NextLevel = 2;

    bool paused = false;
    private void Start()
    {
        
    }    
    void Update()
    {
       
        GameController upgrade = GameObject.FindGameObjectWithTag("GameController").GetComponent("GameController") as GameController;
        upgrade.nextScore = NextLevel;
        if (upgrade.Score >= NextLevel)
        {
            NextLevel += upgrade.Score;
        
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
                allButtons.SetActive(true);
            }
        }
    }
    public void ShowUpgradeShipButtons()
    {
        mainButtons.SetActive(false);
        upgradeShip.SetActive(true);
    }
    public void ShowUpgradeShotButtons()
    {
        mainButtons.SetActive(false);
        upgradeShot.SetActive(true);
    }
    public void ShowBonusesButtons()
    {
        bonuses.SetActive(true);
        mainButtons.SetActive(false);
        
    }
    public void BackFromShip()
    {
        mainButtons.SetActive(true);
        upgradeShip.SetActive(false);
    }
    public void BackFromShot()
    {
        mainButtons.SetActive(true);
        upgradeShot.SetActive(false);
    }
    public void BackFromBonuses()
    {
        mainButtons.SetActive(true);
        bonuses.SetActive(false);
    }
    public void UpgradeDamage()
    {
        Time.timeScale = 1;
        paused = false;
        mainButtons.SetActive(true);
        allButtons.SetActive(false);
        GameController upgrade = GameObject.FindGameObjectWithTag("GameController").GetComponent("GameController") as GameController;
        upgrade.Score = 0;
        upgrade.nextScore = NextLevel;
        upgrade.lifesForLevel++;
       /* var asteroid = FindObjectOfType<AsteroidSpawn>();
        asteroid.*/ //доделать!!!!!!!!!!!!!
    }
    public void ShipUpgrade()
    {
        Time.timeScale = 1;
        paused = false;
        allButtons.SetActive(false);
    }
}
