using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportPoint;
    public GameObject Effect1;
    public GameObject Effect2;

    bool active = true;

    void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            StartCoroutine(Relocate(other));
        }
    }

    IEnumerator MakeEffect(Vector3 position)
    {
        GameObject effect1 = Instantiate(Effect1, position, Quaternion.Euler(-90f, 0f, 0f));
        effect1.transform.localScale = new Vector3(3, 3, 3);
        GameObject effect2 = Instantiate(Effect2, position, Quaternion.Euler(-90f, 0f, 0f));
        effect2.transform.localScale = new Vector3(2, 2, 2);
        yield return new WaitForSeconds(1.5f);
        Destroy(effect1);
        Destroy(effect2);
    }

    IEnumerator Relocate(Collider other)
    {
        StartCoroutine(MakeEffect(transform.position));
        yield return new WaitForSeconds(1);
        
        // отключаем второй телепорт на 1.5 сек
        Teleport teleport = teleportPoint.GetComponent<Teleport>();
        StartCoroutine(teleport.Disable(1.5f));

        StartCoroutine(MakeEffect(teleport.transform.position));
        
        other.enabled = false;
        other.transform.position = teleportPoint.position;
        other.enabled = true;
    }

    public IEnumerator Disable(float seconds)
    {
        active = false;
        yield return new WaitForSeconds(seconds);
        active = true;
    }
}
