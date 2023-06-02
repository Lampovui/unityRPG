using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator buttonAnimator;
    public Animator gatesAnimator;
    void OnTriggerEnter(Collider other) {
        buttonAnimator.enabled = true;
        gatesAnimator.enabled = true;    
    }
}
