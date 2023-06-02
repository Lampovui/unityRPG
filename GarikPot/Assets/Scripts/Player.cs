using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject fireball;
    public Transform attackPoint;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI coinsText;

    public int coins = 0;
    public int healthMax = 100;
    public int health = 100;

    public Animator damageMaskAnimator;
    bool animatorActive = false;
    public AudioSource audioSource;
    public AudioClip damageSound;

    void Start()
    {
        healthText.text = health.ToString();
        coinsText.text = coins.ToString();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject missile = Instantiate(fireball, attackPoint.position, attackPoint.rotation);
            missile.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
    }

    public void CollectCoin()
    {
        coins++;
        coinsText.text = coins.ToString();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        audioSource.PlayOneShot(damageSound);
        if (!animatorActive)
        {
            damageMaskAnimator.enabled = true;
            animatorActive = true;
        }
        else
        {
            damageMaskAnimator.Play("RedFilter", -1, 0f);
        }
        if (health > 0)
        {
            // маска урона и звук
            healthText.text = health.ToString();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
