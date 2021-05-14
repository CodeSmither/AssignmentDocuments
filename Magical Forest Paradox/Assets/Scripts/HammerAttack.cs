using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour
{
    // checks if the player has the hammer
    public bool HammerUnlock = true;
    // an object containing the hammer attack hitbox
    public GameObject Hammer_Attack;
    // the cooldown for the hammer attack
    public bool Cooldown = false;
    // the hammer attacks animator for it's animation
    public Animator animator;
    // checks if the player is currently using their hammer
    public bool Hammering = false;
    
    void Update()
    {
        UpdateHammer();
        // makes the hammer animate if it's being used
        animator.SetBool("Hammer", Hammering);
    }
    void UpdateHammer()
    {
        // checks if the player has got the hammer
        if (HammerUnlock == true)
        {
            // checks if the player is pressing Z
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    // checks if the player is the hammer cooldown is active
                    if (Cooldown == false)
                    {
                        // activates the hammer attack
                        Hammer_Attack.SetActive(true);
                        // activates the cooldown and the Hammer and activates it's animation 
                        Cooldown = true;
                        Hammering = true;
                       
                        Invoke("StopHammer", 3f);
                    }
                }
            // ends the hammer attack when it is no longer being used
            if (Input.GetKeyUp(KeyCode.Z))
            {   
                Hammer_Attack.SetActive(false);
            }
        }
    }
    // ends the hammer attack and ends the cool down
    void StopHammer()
    {
        Hammer_Attack.SetActive(false);
        Cooldown = false;
        Hammering = false;
    }
}
