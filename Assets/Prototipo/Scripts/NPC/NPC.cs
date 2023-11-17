using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
       // Set Initial Animation 
       animator = GetComponent<Animator>();
        setInitalState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setInitalState(){
        animator.SetTrigger("Grounded");
    }
}
