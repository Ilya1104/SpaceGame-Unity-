using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    
    
    public int Score = 0;
    public GameObject ScoreText;
    public int lifes = 0;
    public GameObject LifesText;
    public int nextScore;
    public int lifesForLevel;
    public int totalscore;

    // Создание переменной «враг»
    public GameObject enemy;
    public void Count()
    {
        Score++;
        totalscore++;     
    }   
    public void LifeCounter()
    {
        lifes++;      
    }

    // Временные промежутки между событиями, кол-во врагов
    public float timeBeforeSpawning;
    public float timeBetweenEnemies;
    public float timeBeforeWaves;
    public int enemiesPerWave;
    private int currentNumberOfEnemies = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        lifesForLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("score",totalscore);
        ScoreText.GetComponent<Text>().text = "Score: " + Score+"/"+nextScore;
        LifesText.GetComponent<Text>().text = "Lifes: " + lifes;
    }
    // Появление волн врагов
    // Появление волн врагов
    // Появление волн врагов
    IEnumerator SpawnEnemies()
    {
        // Начальная задержка перед первым появлением врагов
        yield return new WaitForSeconds(timeBeforeSpawning);
        // Когда таймер истекёт, начинаем производить эти действия
        while (true)
        {
            // Не создавать новых врагов, пока не уничтожены старые
            if (currentNumberOfEnemies <= 0)
            {
                // Создать 10 врагов в случайных местах за экраном
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    // Задаём случайные переменные для расстояния и направления
                  
                    // Используем переменные для задания координат появления врага
                    float randomXposition = Random.Range((-transform.localScale.x) / 2, transform.localScale.x / 2);
                    Vector3 spawnPosition = new Vector3(randomXposition, transform.position.y, transform.position.z);

                    // Создаём врага на заданных координатах
                    Instantiate(enemy, spawnPosition, Quaternion.Euler(-90,180,0));
                    currentNumberOfEnemies++;
                    yield return new WaitForSeconds(timeBetweenEnemies);
                }
            }
            // Ожидание до следующей проверки
            yield return new WaitForSeconds(timeBeforeWaves);
        }
    }
    // Процедура уменьшения количества врагов в переменной
    public void KilledEnemy()
    {
        currentNumberOfEnemies--;
        Count();
    }
    public void KilledPlayer()
    {
        lifes--;
        
    }

}
