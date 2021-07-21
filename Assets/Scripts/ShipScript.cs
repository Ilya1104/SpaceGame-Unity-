using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Boundaries
{
    public float up, down, left, right;
}
public class ShipScript : MonoBehaviour
{
    public float stopTime;
    bool paused = false;

    public int playerHealth;
    [SerializeField]private int maxHealth;
    [SerializeField]private int damage;
    [SerializeField]private int shotSpeed;

    public Boundaries boundaries;// границы и перемещение
    public float velocity;
    public float tilt;
    private float rotationShipY = -90;
    private float rotationShipX = -90;
    private float rotationShipZ = -90;

    public GameObject shot;     //снаряд
    public Transform gunPosition;       //позиция пушки
    public Transform positionEnigineGun;

    [SerializeField]private double shotDelay;        //задержка
    private double nextShot;         //след. выстрел
    public HealthBarr h;
    [SerializeField] private MeshCollider meshCol;

    private int shipNumber=0;
    public Mesh _mesh0;
    public Mesh _mesh1;
    public Mesh _mesh2;
    public Mesh _mesh3;
    public Mesh _mesh4;
    List<Mesh> meshes = new List<Mesh>() { };    
 //   Mesh[] s = new Mesh[] { "bjbj" }
    private void Start()
    {
        meshes.Add(_mesh0);
        meshes.Add(_mesh1);
        meshes.Add(_mesh2);
        meshes.Add(_mesh3);
        meshes.Add(_mesh4);
    }
    private void Update()
    {
        bool canShot = Time.time > nextShot;
     //   if ( Input.GetButton("Fire1") && canShot)
         if (Input.touchCount>0 && canShot)
            {
            nextShot = Time.time + shotDelay;
             Instantiate(shot, gunPosition.position, Quaternion.Euler(0,0,0)); //СОЗДАНИЕ ВЫСТРЕЛА
        }
        SetMaxHealth();
        SetOldShip();
    }
    
    public int SetDamageeeeeeeeeee()
    {
      return damage;
    }
    public void Damageeeeeeeeeee()
    {
        damage++;
    }
    //////////////////
    public int SetMaxHealth()
    {
        return maxHealth=int.Parse(h.slider.maxValue.ToString());
    }
    public void MaxHealth()
    {
        playerHealth = maxHealth;
        h.SetHealth(maxHealth);
    }
    ////////////////////
    public int SetShotSpeed()
    {
        return shotSpeed;
    }
    public void ShotSpeeeeeeeeeed()
    {
        if (shotDelay >= 0.2 && shotSpeed < 30)
        {
            shotDelay -= 0.1;        
            shotSpeed += 2;
        }       
    }
    ///////////////////
    public float SetOldShip()
    {
        return velocity;
    }
    public void UpgradeOldShip()
    {
        velocity+=2;
        if(tilt<=4)
        {
            tilt++;
        }
    }
    public float Shipsssssss()
    {
        return shipNumber;
    }
    //////////////////  
    public void NewShip()
    {
        
        for(int i=0;i<+meshes.Count;i++)
        {
            GetComponent<MeshFilter>().mesh = meshes[shipNumber];
            if (shipNumber == 0)
            {
               meshCol.sharedMesh = meshes[shipNumber];
               rotationShipY = 90;
               
               positionEnigineGun.rotation = Quaternion.Euler(0, 90, 0);
            }
            if (shipNumber == 1)
            {
                meshCol.sharedMesh = meshes[shipNumber];
                rotationShipY = 0;
                positionEnigineGun.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (shipNumber == 3)
            {
                meshCol.sharedMesh = meshes[shipNumber];
                rotationShipY = 0;
                positionEnigineGun.rotation = Quaternion.Euler(0,-90, 0);
            }
            if (shipNumber == 4)
            {
                meshCol.sharedMesh = meshes[shipNumber];
                rotationShipY = 180;
                positionEnigineGun.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
        shipNumber++;
    }   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Life")
        {
            GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent("GameController") as GameController;
            controller.LifeCounter();
        }
        if (other.gameObject.tag == "Bullet")
        {
            return;
        }
        if (other.gameObject.tag == "Asteroid")
        {
            AsteroidScript asteroid = other.gameObject.GetComponent<AsteroidScript>();
            playerHealth -= asteroid.asteroidDamage;
            h.SetHealth(playerHealth);
        }
        if (other.gameObject.tag == "EnemyBullet")
        {
            EnemyBullet bullet = other.gameObject.GetComponent<EnemyBullet>();
            playerHealth -= bullet.bulletDamage;
            h.SetHealth(playerHealth);
        }
        if (playerHealth<=0)
        {
            GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent("GameController") as GameController;
            if (controller.lifes <= 0)
            {

                Destroy(gameObject);

                    Time.timeScale = 0;
                var save = FindObjectOfType<StopMenu>();
                    save.DestroyedPlayer();
                
               
            }
            else
            {
                controller.lifes--;
                controller.LifesText.GetComponent<Text>().text = "Lifes: " + controller.lifes;                
                h.SetHealth(maxHealth);
                playerHealth = maxHealth;
                
            }                   
        }
        Destroy(other.gameObject);       
    }
  
   
    private void FixedUpdate()
    {
        float horizontal = Input.acceleration.x;
        // float horizontal =Input.GetAxis("Horizontal");
        //float vertical = Input.acceleration.z;
        float vertical =Input.GetAxis("Vertical");

        Rigidbody Ship = GetComponent<Rigidbody>();
        Ship.velocity = new Vector3(horizontal, 4.0f, vertical)* velocity;

       float xPosition = Mathf.Clamp(Ship.position.x,boundaries.left,boundaries.right );
        float zPosition = Mathf.Clamp(Ship.position.z, boundaries.down, boundaries.up);
        Ship.position = new Vector3(xPosition, 4.0f, zPosition);

        Ship.rotation = Quaternion.Euler(Ship.velocity.x*-tilt, rotationShipY, Ship.velocity.z * tilt);
    }
}
