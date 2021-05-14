using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttack : MonoBehaviour
{
    // This object is the actual projectile
    public GameObject AttackBall;
    // This Object is the projectiles Rigidbody used for adding force
    public Rigidbody2D AttackBallpos;
    // This is used to store the direction of force wanted
    Vector2 straightforward;
    void Update()
    {
        // This selects the direction to send the projectile and adds it as a force
        straightforward = new Vector2(0, -1f);
        AttackBallpos.AddForce(straightforward, ForceMode2D.Impulse);
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // this destroys the ball if gets to close
        if(col.gameObject.tag == "Enviroment")
        {
            Destroy(AttackBall);
        }
    }

}
