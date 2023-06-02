using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;
    public float timmer;

    public GameObject ExplosionEffect;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        timmer += Time.deltaTime;
        if (timmer > 2)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Platform")
        {
            return;
        }
        Instantiate(ExplosionEffect, transform.position, transform.rotation);
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.Die();
        }
        Destroy(gameObject);
    }
}
