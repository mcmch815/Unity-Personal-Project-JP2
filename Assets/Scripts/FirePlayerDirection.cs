using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlayerDirection : MonoBehaviour
{

    public float speed;
    private GameObject player;
  
    // Start is called before the first frame update
    private Vector3 lookDirection;
    void Start()
    {
    
      
       if( GameObject.Find("Player") != null){
      
             player = GameObject.Find("Player");

            transform.LookAt(player.transform.position);
            transform.Rotate(90, 0, 0, Space.Self);
       
         }
    }

    // Update is called once per frame
    void Update()
    {
      if( GameObject.Find("Player") != null){  
      // projectileRb.AddForce(lookDirection * speed * Time.deltaTime);
      transform.Translate(Vector3.up * Time.deltaTime * speed);
      }

        if(transform.position.x > 25 || transform.position.x < -25 || transform.position.z > 25 || transform.position.z < -25 )
         {
            Destroy(gameObject);

         }

    }
}
