using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject life;
    public float minAsteroidDelay, maxAsteroidDelay;
    public float minLifeDelay, maxLifeDelay;
    private float nextAsteroid; //создание след. астероида
    private float nextLife;
    private int countLife = 1;
    private float countOfAsteroid = 1;
    public float asteroidIncrease;

    // Update is called once per frame
    void Update()
    {
        GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent("GameController") as GameController;
        if (Time.time > nextAsteroid)
        {
            float maxAsteroid = Random.Range(1, countOfAsteroid);
            for (int i = 0; i < maxAsteroid; i++)
            {
                float randomXposition = Random.Range((-transform.localScale.x) / 2, transform.localScale.x / 2);
                Vector3 spawnPosition = new Vector3(randomXposition, transform.position.y, transform.position.z);
                Instantiate(asteroid, spawnPosition, Quaternion.identity);
            }                
            //countOfAsteroid += asteroidIncrease;
            nextAsteroid += Random.Range(minAsteroidDelay, maxAsteroidDelay);            
        }
        //if (Time.time > nextLife)
        //{
        //    if (countLife <= controller.lifesForLevel)
        //    {
        //        for (int i = 0; i < countLife; i++)
        //        {
        //            float randomXposition = Random.Range((-transform.localScale.x) / 2, transform.localScale.x / 2);
        //            Vector3 spawnPosition = new Vector3(randomXposition, transform.position.y, transform.position.z);
        //            Instantiate(life, spawnPosition, Quaternion.Euler(-90, 180, 0));
        //            countLife++;
        //        }
        //        nextLife += Random.Range(minLifeDelay, maxLifeDelay);
                
        //    }
        //}
        
    }
}
