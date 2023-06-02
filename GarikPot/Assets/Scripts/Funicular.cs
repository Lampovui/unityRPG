using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funicular : MonoBehaviour
{
    public Animator animator;
    Vector3 prevPos;
    Collider player;

    void Start()
    {
        prevPos = transform.position;
    }

    void Update()
    {
        Vector3 dPos = transform.position - prevPos;
        if (dPos.x != 0 && dPos.y != 0 && dPos.z != 0)
        {
            return;
        }
        prevPos = transform.position;
        MovePlayer(dPos);
    }

    void MovePlayer(Vector3 dPos)
    {
        if (player)
        {
            Vector3 newPos = player.transform.position + dPos;
            player.enabled = false;
            player.transform.position = newPos;
            player.enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            player = other;
            animator.enabled = true;
        }
    }
}
