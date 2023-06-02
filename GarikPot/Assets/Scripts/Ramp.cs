using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Ramp : MonoBehaviour
{
    [Range(1, 3)]
    [Tooltip("Во сколько раз увеличить скорость")]
    public float speedFactor = 2;

    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<FirstPersonController>().m_RunSpeed *= speedFactor;
    }

    void OnTriggerExit(Collider other)
    {
        other.GetComponent<FirstPersonController>().m_RunSpeed /= speedFactor;
    }
}
