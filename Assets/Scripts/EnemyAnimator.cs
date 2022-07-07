using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour

{


    private Animator enemyAnim;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
       enemyAnim.SetBool("Walk Forward", true); 
    }
}
