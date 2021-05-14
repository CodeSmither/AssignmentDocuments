using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttack2 : MonoBehaviour
{
    // This object is the actual projectile
    Vector2 rightforward;
    // This Object is the projectiles Rigidbody used for adding force
    public GameObject AttackBall2;
    // This is used to store the direction of force wanted
    public Rigidbody2D AttackBallpos2;

    
    void Update()
    {
        // This selects the direction to send the projectile and adds it as a force
        rightforward = new Vector2(1f, -1f);
        AttackBallpos2.AddForce(rightforward, ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // this destroys the ball if gets to close
        if (col.gameObject.tag == "Enviroment")
        {
            Destroy(AttackBall2);
        }
    }
}
