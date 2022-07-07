using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

//speed variable 

    private float speed = 5.0f;
    private Rigidbody playerRb;
    
    public bool gameOver = false;

    private GameObject collectable;


    // Start is called before the first frame update
    void Start()
    {
     playerRb = GetComponent<Rigidbody>();   
    
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            MovePlayer();
        }

         //game over if player falls off
        if (transform.position.y < -10)
        {
            gameOver = true;
            Destroy(gameObject);
        }

          if( GameObject.FindGameObjectsWithTag("Collectable") != null)
        {

            collectable = GameObject.FindGameObjectWithTag("Collectable");
            Debug.Log("Collectable found");
             Vector3 direction = (collectable.transform.position - transform.position);
            var step = 100* Time.deltaTime;
            //make player look at collectable
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, direction, step, 0.0f));
           
             
             

        }
    }

    //Move player method
    void MovePlayer(){

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);

       

    }

    private void OnCollisionEnter(Collision collision)
    {
        // If enemy collides with player, kill the player
        if (collision.gameObject.CompareTag("Enemy") )
        {
            gameOver = true;
            Destroy(gameObject);
            Debug.Log("Game Over!");
           
        }


    }


    private void OnTriggerEnter(Collider other){
        //if enemy projectile collides with player, kill player
        if(other.CompareTag("Enemy Projectile")){
            
            gameOver = true;
            Destroy(gameObject);
            Debug.Log("Game Over!");

        }
    }


}
