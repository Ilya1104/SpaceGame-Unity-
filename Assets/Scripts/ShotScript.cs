using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{

    public float speed;
  /*  private int bulletDamage=1;
   
    private int updateDamage =0;//доделать!!!!!!  */
    public int totalDamage;
    

    public void Start()
    {
        var ship = FindObjectOfType<ShipScript>();
        totalDamage = ship.SetDamageeeeeeeeeee();
        speed = ship.SetShotSpeed();
    }
    public void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,speed);
    }
   

}
