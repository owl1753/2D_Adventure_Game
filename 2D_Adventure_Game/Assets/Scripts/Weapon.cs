using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Player player;
    public Transform firePoint;
    public GameObject firePrefab;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isAttack)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(firePrefab, firePoint.position, firePoint.rotation);
    }
}
