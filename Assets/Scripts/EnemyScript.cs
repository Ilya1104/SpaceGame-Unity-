using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Transform player;
  
    public double enemyHealth;
  

    public GameObject explosion;

    public Boundaries EnemyBoundaries;// границы и перемещение
  
    // Скорость движения врага
    public float speed;

   
    // Use this for initialization
    void Start()
    {            
            player = GameObject.Find("Корабль").transform;
    }
    // Update is called once per frame

    //атакование игрока
    private void Following(Transform other)
    {

        //ShipScript s = other.gameObject.GetComponent<ShipScript>();

        Vector3 delta = player.position - transform.position;
        Rigidbody Ship = GetComponent<Rigidbody>();
        float moveSpeed = speed * Time.deltaTime;
        Ship.velocity = delta * moveSpeed;

        float xPosition = Mathf.Clamp(Ship.position.x, EnemyBoundaries.left, EnemyBoundaries.right);
        float zPosition = Mathf.Clamp(Ship.position.z, EnemyBoundaries.down, EnemyBoundaries.up);
        Ship.position = new Vector3(xPosition, 4.0f, zPosition);
        delta.Normalize();


    }
    void Update()
    {
        if (player != null)
        {
            Following(player);
        }
    }

    //бой,стрельба,драка
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid" || other.tag=="Enemy")
        {
            return;
        }
        if (other.gameObject.tag == "EnemyBullet")
        {
            return;
        }
        if (other.gameObject.tag == "Bullet")
        {
            ShotScript bullet= other.gameObject.GetComponent<ShotScript>();
            enemyHealth -= bullet.totalDamage;
            Destroy(other.gameObject);           
        }
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent("GameController") as GameController;
            controller.KilledEnemy();
        }
        Destroy(other.gameObject);       
    }
   
}
