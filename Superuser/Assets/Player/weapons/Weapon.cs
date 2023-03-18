using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 100.0f;

    public GameObject player;

    void Start()
    {
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, player.transform.rotation);
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), player.GetComponent<Collider>());

        bullet.GetComponent<Rigidbody>().velocity = player.transform.forward * fireForce;
    }
}
