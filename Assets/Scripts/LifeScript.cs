using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    private int speed = 10;

    private void Start()
    {
        Rigidbody life = GetComponent<Rigidbody>();
        life.velocity = Vector3.back*speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="GameArea")
        {
            return;
        }
    }
}
