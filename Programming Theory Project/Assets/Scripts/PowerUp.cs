using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPowerUP
{
    void DoSpecialAction(); // ABSTRACTION
    void DoCollisionAction(Collision collision); // ABSTRACTION
    void Destroy(); // ABSTRACTION
}

public abstract class PowerUp : MonoBehaviour, IPowerUP
{
    protected GameObject player { get; private set; } // ENCAPSULATION
    protected Rigidbody playerRb;

    public void Start()
    {
        player = GameObject.Find("Player");
        playerRb = player.GetComponent<Rigidbody>();
    }
    public virtual void DoSpecialAction()
    { }

    public virtual void DoCollisionAction(Collision collision)
    { }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            playerController.SetPowerUp(this);
            gameObject.SetActive(false);
        }
    }
}
