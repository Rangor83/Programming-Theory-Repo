using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public bool hasPowerup = false;
    public bool hasMissile = false;
    public bool hasJump = false;
    public GameObject powerupIndicator;

    private Rigidbody playerRb;
    private GameObject focalPoint;

    IPowerUP powerUp;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (hasPowerup && Input.GetKeyDown(KeyCode.F) && powerUp != null)
        {
            powerUp.DoSpecialAction();
        }

        if (transform.position.y < -10)
        {
            GameOver();
        }
    }

    public void SetPowerUp(IPowerUP pu)
    {
        if (powerUp != null)
        {
            powerUp.Destroy();
            powerUp = null;
        }
        powerUp = pu;
        powerupIndicator.gameObject.SetActive(true);
        hasPowerup = true;
        StartCoroutine(PowerupCountdownRutine());
    }

    IEnumerator PowerupCountdownRutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerUp.Destroy();
        powerUp = null;
        powerupIndicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (hasPowerup)
        {
            powerUp.DoCollisionAction(collision);
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
