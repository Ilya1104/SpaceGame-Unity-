using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float minRotationSpeed, maxRotationSpeed, minMoveSpeed,maxMoveSpeed;
    public GameObject explosion;
    public GameObject playerExplosion;
    public double health = 2;
    public int asteroidDamage;

    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * Random.Range(minRotationSpeed, maxRotationSpeed);
        asteroid.velocity = Vector3.back * Random.Range(minMoveSpeed, maxMoveSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="GameArea" || other.tag == "Asteroid")
        {
            return;
        }

        if(other.tag=="Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }

        if (other.gameObject.tag== "Bullet")
        {
            ShotScript bullet = other.gameObject.GetComponent<ShotScript>();
            health -= bullet.totalDamage;         //доделать!!!!!!         
            Destroy(other.gameObject);
            if (health <= 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        
    }
    void Update()
    {
        
    }
}
