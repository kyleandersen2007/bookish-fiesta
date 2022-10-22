using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health;
    public GameObject hitEffect;
    public GameObject deathBloodPrefab;
    EnemyHPBar hpBar;

    private void Awake()
    {
        hpBar = GetComponentInChildren<EnemyHPBar>();
    }

    private void Start()
    {
        hpBar.SetMaxHealth(health);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        hpBar.SetHealth(health);

        if (health <= 0)
        {
            OnDead();
        }
    }

    private void OnDead()
    {
        Instantiate(deathBloodPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void CreateBlood(Vector3 pos, Vector3 normal)
    {
        GameObject blood = Instantiate(hitEffect, pos, Quaternion.FromToRotation(Vector3.up, normal));
        Destroy(blood, 1f);
    }
}