using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    enum ElevatorState
    {
        idle,
        rising,
        falling
    }
    public float speed;
    public GameObject TopPlatform;
    public Vector3 direction;
    ElevatorState state = ElevatorState.rising;
    Collider player;

    void OnTriggerEnter(Collider other)
    {
        float dist = Vector3.Distance(TopPlatform.transform.position, transform.position);
        if (other.tag == "Platform" && dist > 0.5f) {
            state = ElevatorState.idle;
        }
        if (other.tag == "Player") {
            player = other;
            state = ElevatorState.rising;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            state = ElevatorState.falling;
        }
    }

    void Update()
    {
        float dist = Vector3.Distance(TopPlatform.transform.position, transform.position);
        if (state == ElevatorState.rising && dist > 0.5f)
        {
            if (player)
            {
                player.enabled = false;
                player.transform.position += direction * speed * Time.deltaTime;
                player.enabled = true;
            }
            transform.position += direction * speed * Time.deltaTime;
        }
        else if (state == ElevatorState.falling)
        {
            transform.position -= direction * speed * Time.deltaTime;
        }
    }
}
