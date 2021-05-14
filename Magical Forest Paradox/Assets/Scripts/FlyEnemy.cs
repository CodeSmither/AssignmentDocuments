using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    // the player's current position
    public Transform PlayersPosition;
    // the fly's current position
    public Transform CurrentPosition;
    // the fly's rigidbody
    public Rigidbody2D Flybody;
    // the fly's movement speed
    public float FlySpeed = 10f;
    // where the fly wants to move to
    Vector2 Targetposition;
    // checks if the fly is currently flying
    public bool flying = false;
    // checks if the fly is currently stunned
    public bool stunned = false;
    // checks if the fly has an attack cool down 
    public bool cooldown = false;
    // checks if the fly is attacking
    public bool attacking = false;
    // the fly's attack gameobjects
    public GameObject FlyBall;
    public GameObject FlyBall2;
    public GameObject FlyBall3;
    // the fly's health
    public int BugHealth = 3;
    // the fly's renderer controlling it's colour
    public Renderer Renderer;
    // the players weapon colliders
    public BoxCollider2D Stabdown;
    public BoxCollider2D Stabup;
    public BoxCollider2D Stableft;
    public BoxCollider2D Stabright;
    // the fly as a game object
    public GameObject Fly;
    // the flys animator
    public Animator animator;


    public void Update()
    {   // makes the animator check if the fly is stunned,flying or attacking
        animator.SetBool("Stunned", stunned);
        animator.SetBool("Flying", flying);
        animator.SetBool("Attacking", attacking);
        // makes the fly move above the player if they are in range and the fly isn't stunned
        if (Vector2.Distance(PlayersPosition.position, CurrentPosition.position) <= 7 && stunned == false)
        {
            Targetposition = new Vector2(PlayersPosition.position.x - CurrentPosition.position.x, PlayersPosition.position.y - CurrentPosition.position.y + 5);
            Flybody.MovePosition(Flybody.position + Targetposition / 5 * Time.fixedDeltaTime * FlySpeed);
            flying = true;
        }
        else
        {// makes the fly stop flying when the player is out of range
            flying = false;
            // makes the fly become un stunned after 4 seconds
            if (stunned == true)
            {
                Invoke("Unstun", 4f);
            }

            
        }
        // checks if the fly is in position for an attack
        if (CurrentPosition.position.y > PlayersPosition.position.y + 4 && flying == true)
        {
            Attack();
        }
        // checks if the fly's health is 0 and destroys it if it does
        if (BugHealth <= 0)
        {
            Destroy(Fly);
        }
    }
    public void Attack()
    {// checks if the cooldown for the attack is over
        if (cooldown == false)
        {
            //tells the animator that the fly is attack
            attacking = true;
            // creates 3 Flyball attacks
            GameObject Attack;
            GameObject Attack2;
            GameObject Attack3;
            Attack = Instantiate(FlyBall, CurrentPosition);
            Attack2 = Instantiate(FlyBall2, CurrentPosition);
            Attack3 = Instantiate(FlyBall3, CurrentPosition);
            // activates the 3 Flyball attacks
            Attack.SetActive(true);
            Attack2.SetActive(true);
            Attack3.SetActive(true);
            // sets the attack cooldown to active
            cooldown = true;
            Invoke("cooldownfunc", 5f);
            Invoke("AttackOver", 1f);
        }
    }
    public void AttackOver()
    {// tells the fly that they have stopped attacking for the animator
        attacking = false;
    }
    public void cooldownfunc()
    {// causes the attack cool down to end
        cooldown = false;
    }
    private void OnTriggerEnter2D(Collider2D HammerCollider)
    {// checks if the player has used a hammer to stun the fly
        if (HammerCollider.gameObject.tag == "Hammer")
        {
            stunned = true;
        }
    // checks if the player has attacked the fly and deals damage and shows the fly as damaged by changing it to red colour
        if (HammerCollider == Stabdown)
        {
            BugHealth = BugHealth - 1;

            Renderer.material.color = Color.Lerp(Color.white, Color.red, 1f);
            Invoke("BackToNormal", 0.5f);
        }
        if (HammerCollider == Stabup)
        {
            BugHealth = BugHealth - 1;
            Renderer.material.color = Color.Lerp(Color.white, Color.red, 1f);
            Invoke("BackToNormal", 0.5f);
        }
        if (HammerCollider == Stableft)
        {
            BugHealth = BugHealth - 1;
            Renderer.material.color = Color.Lerp(Color.white, Color.red, 1f);
            Invoke("BackToNormal", 0.5f);
        }
        if (HammerCollider == Stabright)
        {
            BugHealth = BugHealth - 1;
            Renderer.material.color = Color.Lerp(Color.white, Color.red, 1f);
            Invoke("BackToNormal", 0.5f);
        }
    }
    public void Unstun()
    {// unstuns the fly
        stunned = false;
    }
    void BackToNormal()
    {// makes the fly return back to normal colour
        Renderer.material.color = Color.Lerp(Color.red, Color.white, 1f);
    }
}
