using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int health=500;
    public GameObject Effect;
        public bool IsInv =false;
    public Slider HealthBar;
    public void TakeDamage(int damage)
    {
        HealthBar.value = health;
        if (IsInv)
            return;

        health-= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(Effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
