using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemyScript : MonoBehaviour
{
    public float EnemyShotDelay;        //задержка
    private float nextShot;         //след. выстрел

    public GameObject shot;     //снаряд
    public Transform gunPosition;       //позиция пушки  
    void Update()
    {
        bool canShot = Time.time > nextShot;
        if (canShot)
        // if (Input.touchCount>0 && canShot)
        {
            nextShot = Time.time + EnemyShotDelay;
            Instantiate(shot, gunPosition.position, Quaternion.Euler(0, 0, 0)); //СОЗДАНИЕ ВЫСТРЕЛА
        }
    }
}
