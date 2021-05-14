using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttack3 : MonoBehaviour
{
    // This object is the actual projectile
    public GameObject AttackBall3;
    // This Object is the projectiles Rigidbody used for adding force
    public Rigidbody2D AttackBallpos3;
    // This is used to store the direction of force wanted
    Vector2 leftforward;

    
    void Update()
    {
        // This selects the direction to send the projectile and adds it as a force
        leftforward = new Vector2(-1f, -1f);
        AttackBallpos3.AddForce(leftforward, ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // this destroys the ball if gets to close
        if (col.gameObject.tag == "Enviroment")
        {
            Destroy(AttackBall3);
        }
    }
}
