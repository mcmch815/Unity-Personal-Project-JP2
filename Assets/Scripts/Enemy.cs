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

    public float rotateSpeed;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
      
       playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
     
    }

   
        void Update()
    {
        
            
        //enemy only acts if player exists
        if( GameObject.Find("Player") != null)
        {
            Debug.Log("Player found");
             Vector3 direction = (player.transform.position - transform.position);
            var step = speed * Time.deltaTime;
            //make enemy look at player
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, direction, rotateSpeed, 0.0f));
            //move enemy towards player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
             
             FireProjectile();


        }
 
    //destroy if enemy falls off
        if (transform.position.y < -10)
        {
            
            Destroy(gameObject);
        }


    }

    void FireProjectile(){
        //spwans a projectile
        enemyFiringInternal -= Time.deltaTime;

        if(enemyFiringInternal <=0){
        Instantiate(enemyProjectilePrefab, transform.position, enemyToPlayerRotation);
        enemyFiringInternal = 2;
        }

    }

    
   

}
