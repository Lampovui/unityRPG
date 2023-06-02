using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3 (0, 1, 0));
    }

    void OnTriggerEnter (Collider Col)
    {
        Player player =  Col.GetComponent<Player>();
        if(player != null)
        {
            player.CollectCoin();
            Destroy(gameObject);
        }
    }
}
