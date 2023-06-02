using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject ground;
    void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        ground.SetActive(false);
    }
}
