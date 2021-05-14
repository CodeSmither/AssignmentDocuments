using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderBehaviour : MonoBehaviour
{
    // these the players weapon colliders
    public BoxCollider2D Stabdown;
    public BoxCollider2D Stabup;
    public BoxCollider2D Stableft;
    public BoxCollider2D Stabright;
    // this is the rigidbody of the rock it's self
    public Rigidbody2D rockbody;
    // this a number which is high enough that when used as a force it allows the rock to be pushed by the players weapons but not otherwise
    public float KnifePushForce = 100000000;

    void OnTriggerStay2D(Collider2D col)
    {
        // these 4 if statements apply the force in the correct direction based on the direction opposite to the player attacking
        if(col == Stabdown)
        {
            
            rockbody.AddForce(-transform.up * KnifePushForce);
        }
        if (col == Stabup)
        {
            
            rockbody.AddForce(transform.up * KnifePushForce);
        }
        if (col == Stableft)
        {
            
            rockbody.AddForce(-transform.right * KnifePushForce);
        }
        if (col == Stabright)
        {
            
            rockbody.AddForce(transform.right * KnifePushForce);
        }
    }
}
