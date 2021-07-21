using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public int bulletDamage;
    public void Update()
    {
        GetComponent<Rigidbody>().velocity = Vector3.back*speed;
    }
}
