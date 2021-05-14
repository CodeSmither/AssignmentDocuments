using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // the players health
    public static int Health = 3;
    // the players hitbox
    public CapsuleCollider2D PlayerHitBox;
    // the game objects storing the bugs attacks
    public GameObject ChargeBug;
    public GameObject ChargeBug2;
    public GameObject ChargeBug3;
    public GameObject ChargeBug4;
    // the players renderer controlling it's color
    public Renderer Renderer;
    // the animators for the each health point
    public Animator animator;
    public Animator animator2;
    public Animator animator3;
    


    void Update()
    {// this allows the players health to be displayed
        animator.SetInteger("Health", Health);
        animator2.SetInteger("Health", Health);
        animator3.SetInteger("Health", Health);
    }


    private void OnTriggerEnter2D(Collider2D PlayerBug)
    {// checks if the bugs weapon has hit the player
        if (PlayerBug.IsTouching(PlayerHitBox))
        {// checks if the object hitting them is one of the enemies weapons that being the fly's attack or the chargebugs attack
        // it shows that damage by turning the player red
            if (PlayerBug.gameObject == ChargeBug)
            {
                Health -= 1;
                Renderer.material.color = Color.Lerp(Color.white, Color.red, 1f);
                Invoke("BackToNormal", 0.5f);
            }
            if (PlayerBug.gameObject == ChargeBug2)
            {
                Health -= 1;
                Renderer.material.color = Color.Lerp(Color.white, Color.red, 1f);
                Invoke("BackToNormal", 0.5f);
            }
            if (PlayerBug.gameObject == ChargeBug3)
            {
                Health -= 1;
                Renderer.material.color = Color.Lerp(Color.white, Color.red, 1f);
                Invoke("BackToNormal", 0.5f);
            }
            if (PlayerBug.gameObject == ChargeBug4)
            {
                Health -= 1;
                Renderer.material.color = Color.Lerp(Color.white, Color.red, 1f);
                Invoke("BackToNormal", 0.5f);

            }
            if (PlayerBug.gameObject.layer == 10)
            {
                Health -= 1;
                Renderer.material.color = Color.Lerp(Color.white, Color.red, 1f);
                
                Invoke("BackToNormal", 0.5f);
            }
        }
        
        
    }

    void BackToNormal()
    {// the player is returned to a normal colour
        Renderer.material.color = Color.Lerp(Color.red, Color.white, 1f);
        
    }







}
