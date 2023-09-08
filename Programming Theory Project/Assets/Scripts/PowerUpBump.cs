using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBump : PowerUp
{
    private float powerupStrength = 15.0f;

    public override void DoCollisionAction(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

            Debug.Log("Collided with " + collision.gameObject.name + " with Powerup " + gameObject.name);
        }

    }
}
