using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugBehaviour : MonoBehaviour
{   // this is the main characters position
    public Transform PlayersPosition;
    // this is the bugs position
    public Transform CurrentPosition;
    // this is the rigidbody for the bug
    public Rigidbody2D Bugbody;
    // this is the movement speed for the bug
    public float BugSpeed = 2f;
    //  this is where the bug needs to move using the previous positions as refrence points
    Vector2 Targetposition;
    // this checks if the bug needs to move vertical or horizontal
    public int MoveDirection;
    // this the weapons of the bug 
    public GameObject ChargeBug;
    public GameObject ChargeBug2;
    public GameObject ChargeBug3;
    public GameObject ChargeBug4;
    // this is the bugs animator
    public Animator animator;
    // this checks which direction the bug is moving for the animator
    public bool MovingVertical;
    public bool MovingHorizontal;
    // this is the bugs health to check if it gets damaged
    public int BugHealth = 3;
    // these are the colliders for the players weapons
    public BoxCollider2D Stabdown;
    public BoxCollider2D Stabup;
    public BoxCollider2D Stableft;
    public BoxCollider2D Stabright;
    // this is the bug as a gameobject
    public GameObject Bug;
    // this is the render which controls colour for the object
    public Renderer Renderer;

    // this starts the move selection process to allow the bug to choose which way it wants to move
    public void Start()
    {
        MoveSelection();
    }

    public void Update()
    {
        // this checks if the player is in range of the bug
        if(Vector2.Distance(PlayersPosition.position, CurrentPosition.position) <= 10)
        {
            // this checks if it wants to move horizontal
            if (MoveDirection == 0)
            {
                HorizontalMove();
            }
            // this checks if it want ot move vertical
            if (MoveDirection == 1)
            {
                VerticalMove();
            }
        }
        // this stops the bug from moving if the player is out of range
        else
        {
            MovingVertical = false;
            MovingHorizontal = false;
        }
        // this makes the bug be animated when moving horizontal or vertically
        animator.SetBool("Vertical", MovingVertical);
        animator.SetBool("Horizontal", MovingHorizontal);
        // this kills the bug if it's health becomes 0 or less
        if(BugHealth <= 0)
        {
            Destroy(Bug);
        }
    }
    
    
    public void HorizontalMove()
    {   // this checks if the bug isn't parallel to the player on the x axis
        if (PlayersPosition.position.x != CurrentPosition.position.x)
        {
            // this moves the bug horizontally towards it's target by calculating a position to move to which is parallel to the player
            Targetposition = new Vector2(PlayersPosition.position.x - CurrentPosition.position.x, 0);
            Bugbody.MovePosition(Bugbody.position + Targetposition * Time.fixedDeltaTime * BugSpeed);
        }
        // this activates the bugs horizontally weapons
        ChargeBug.SetActive(true);
        ChargeBug2.SetActive(true);
        ChargeBug3.SetActive(false);
        ChargeBug4.SetActive(false);
        // this sets the animator to the move horizontal by changing the booleans
        MovingVertical = false;
        MovingHorizontal = true;
    }
    
    public void VerticalMove()
    {
        // this checks if the bug isn't parallel to the player on the y axis
        if (PlayersPosition.position.y != CurrentPosition.position.y)
        {
            // this moves the bug vertically towards it's target by calculating a position to move to which is parallel to the player
            Targetposition = new Vector2(0 ,PlayersPosition.position.y - CurrentPosition.position.y);
            Bugbody.MovePosition(Bugbody.position + Targetposition * Time.fixedDeltaTime * BugSpeed);
        }
        // this activates the bugs vertical weapons
        ChargeBug.SetActive(false);
        ChargeBug2.SetActive(false);
        ChargeBug3.SetActive(true);
        ChargeBug4.SetActive(true);
        // this sets the animator to the move vertically by changing the booleans
        MovingHorizontal = false;
        MovingVertical = true;
    }

    public void MoveSelection()
    {// this generates a random number so the bug can select when to change axis to move along
        MoveDirection = Random.Range(0, 2);
        
        NewRandom();
    }
    public void NewRandom()
    {
        // this generates a new random number
        Invoke("MoveSelection", 2f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // these 4 if statement check if the player attacks the bug then lowers the bugs health and shows that to the player by flashing red
        if (col == Stabdown)
        {
            BugHealth = BugHealth - 1;

            Renderer.material.color = Color.Lerp(Color.white, Color.red, 1f);
            Invoke("BackToNormal", 0.5f);
        }
        if (col == Stabup)
        {
            BugHealth = BugHealth - 1;
            Renderer.material.color = Color.Lerp(Color.white, Color.red, 1f);
            Invoke("BackToNormal", 0.5f);
        }
        if (col == Stableft)
        {
            BugHealth = BugHealth - 1;
            Renderer.material.color = Color.Lerp(Color.white, Color.red, 1f);
            Invoke("BackToNormal", 0.5f);
        }
        if (col == Stabright)
        {
            BugHealth = BugHealth - 1;
            Renderer.material.color = Color.Lerp(Color.white, Color.red, 1f);
            Invoke("BackToNormal", 0.5f);
        }
    }
    void BackToNormal()
    {// this returns the player back to normal colour
        Renderer.material.color = Color.Lerp(Color.red, Color.white, 1f);
    }
}
