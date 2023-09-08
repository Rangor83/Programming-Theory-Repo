using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRocket : PowerUp // INHERITANCE
{
    private GameObject tmpRocket;
    public GameObject rocketPrefab;

    public override void DoSpecialAction() // POLYMORPHISM
    {
        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            tmpRocket = Instantiate(rocketPrefab, player.transform.position + Vector3.up, Quaternion.identity);
            tmpRocket.GetComponent<Bullet>().Fire(enemy.transform);
        }
    }
}
