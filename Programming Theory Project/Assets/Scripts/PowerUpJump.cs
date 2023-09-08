using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpJump : PowerUp
{
    public override void DoSpecialAction()
    {
        float jumpForce = 20;
        playerRb.AddForce(-player.transform.forward, ForceMode.Impulse);
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public override void DoCollisionAction(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            foreach (var enemy in FindObjectsOfType<Enemy>())
            {
                Vector3 awayFromPlayer = (enemy.transform.position - player.transform.position).normalized;
                enemy.GetComponent<Rigidbody>().AddForce(awayFromPlayer * 20 / awayFromPlayer.magnitude, ForceMode.Impulse);
            }
            Debug.Log("Collided with " + collision.gameObject.name + " with Powerup " + gameObject.name);
        }
    }
}
