using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StabAttack : MonoBehaviour
{
    // this is the players current movement
    Vector2 movement;
    // these are players attacks as gameobjects
    public GameObject Stabup;
    public GameObject Stabdown;
    public GameObject Stableft;
    public GameObject Stabright;
    // this is the animator for attacks
    public Animator animator;
    // this checks if the player is attacking
    public bool Attacking;

    

    void Update()
    {   // this checks the players movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        // this starts the Update Attacking function
        UpdateAttacking();
        // this tells the animator if the player is attacking
        animator.SetBool("Attacking", Attacking);
    }

    public void UpdateAttacking()
    {// this checks if the player is moving and attack or just attacking and if they have stopped attacking
     // if they have they will the corosponding boolean will be set to true or false

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey(KeyCode.X))
                {
                    Stabup.SetActive(true);
                }
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Stabup.SetActive(false);
                
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Input.GetKey(KeyCode.X))
                {
                Stabdown.SetActive(true);
                }
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                Stabdown.SetActive(false); 
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (Input.GetKey(KeyCode.X))
                {
                Stableft.SetActive(true);
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Stableft.SetActive(false);  
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.X))
                {
                Stabright.SetActive(true);
                }
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                Stabright.SetActive(false);
                
            }
            if (Input.GetKeyDown(KeyCode.X))
            {   // this sets the player to attacking if the press X
                Attacking = true;
                // this checks if the player is moving
                if (movement.sqrMagnitude < 0.01)
                {
                    //sets the non moving attack to true
                    Stabdown.SetActive(true);
                }
                
            }
            if (Input.GetKeyUp(KeyCode.X))
            {   // this stops the attack when they no longer press X
                Attacking = false;
            }
            
            StartCoroutine(AttackCoolDown());
            


    }

    IEnumerator AttackCoolDown()
    {   // this stops the player from constantly attacking giving a short delay of 0.5 seconds
        yield return new WaitForSeconds(0.5f);
        
    }
}
