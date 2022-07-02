using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    public GameObject enemyProjectilePrefab;
    public float enemyFiringInternal = 1;
    public float startDelay = 2;
    private Quaternion enemyToPlayerRotation;
   
    private PlayerController playerControllerScript;
  

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
       
       playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
       InvokeRepeating("FireProjectile", startDelay, enemyFiringInternal);

    }

    // Update is called once per frame
    void Update()
    {
        //enemy only acts if player exists
        if( GameObject.Find("Player") != null)
        {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

        Vector3 direction = (player.transform.position - transform.position);
     
        enemyToPlayerRotation.SetLookRotation(direction, Vector3.forward);
        }
 
    //destroy if enemy falls off
        if (transform.position.y < -10)
        {
            
            Destroy(gameObject);
        }


    }

    void FireProjectile(){
        //spwans a projectile
        Instantiate(enemyProjectilePrefab, transform.position, enemyToPlayerRotation);


    }

    
   

}
