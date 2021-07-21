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

    // �������� ���������� �����
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

    // ��������� ���������� ����� ���������, ���-�� ������
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
    // ��������� ���� ������
    // ��������� ���� ������
    // ��������� ���� ������
    IEnumerator SpawnEnemies()
    {
        // ��������� �������� ����� ������ ���������� ������
        yield return new WaitForSeconds(timeBeforeSpawning);
        // ����� ������ ������, �������� ����������� ��� ��������
        while (true)
        {
            // �� ��������� ����� ������, ���� �� ���������� ������
            if (currentNumberOfEnemies <= 0)
            {
                // ������� 10 ������ � ��������� ������ �� �������
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    // ����� ��������� ���������� ��� ���������� � �����������
                  
                    // ���������� ���������� ��� ������� ��������� ��������� �����
                    float randomXposition = Random.Range((-transform.localScale.x) / 2, transform.localScale.x / 2);
                    Vector3 spawnPosition = new Vector3(randomXposition, transform.position.y, transform.position.z);

                    // ������ ����� �� �������� �����������
                    Instantiate(enemy, spawnPosition, Quaternion.Euler(-90,180,0));
                    currentNumberOfEnemies++;
                    yield return new WaitForSeconds(timeBetweenEnemies);
                }
            }
            // �������� �� ��������� ��������
            yield return new WaitForSeconds(timeBeforeWaves);
        }
    }
    // ��������� ���������� ���������� ������ � ����������
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
