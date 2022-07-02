using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCollosition : MonoBehaviour
{
//effect to play on collection
//public ParticleSystem collectionParticle;

public AudioClip collectSound;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Player")){
           
        }

    }


    void OnTriggerEnter(Collider other){

        //Refer to child object particle effect
       ParticleSystem collectionParticle = GetComponentInChildren<ParticleSystem>();

        Debug.Log("Collected");
        if(collectionParticle.isPlaying) collectionParticle.Stop();
        if(!collectionParticle.isPlaying) collectionParticle.Play();
        
        Destroy(gameObject, 1);
     
        


    }
}
