using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScipt : MonoBehaviour
{
    // this is the movement speed of the player
    public float moveSpeed = 5f;
    // this is the players rigidbody
    public Rigidbody2D PlayerRB;
    // this is the animator for the player
    public Animator animator;
    // this is the movement the player is going to make written as a vector 2
    Vector2 movement;

    void Update()
    {// this takes the players input and adds it to the vector 2
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    // send the direction of the player to the animator
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
    // this checks if the player is moving and sends the result to the animator
        animator.SetFloat("Speed", movement.sqrMagnitude);
        
    }
    void FixedUpdate()
    {
        // this moves the player based on the inputs given frame based on the movement speed given
        PlayerRB.MovePosition(PlayerRB.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    // this Script is inspired by the script used in https://www.youtube.com/watch?v=whzomFgjT50&ab_channel=Brackeys
    // this was used due to it being the most standard model for topdown movement
    // Refrence :
    // Brackleys. (2019, August 11). TOP DOWN MOVEMENT in Unity! (Brackleys, Editor) Retrieved May 6, 2021, from Youtube: https://www.youtube.com/watch?v=whzomFgjT50&ab_channel=Brackeys
    



}
