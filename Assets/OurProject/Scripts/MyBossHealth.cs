using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBossHealth : MonoBehaviour {

    public int bossMaxHealth;
    public int bossCurrentHealth;

    // Use this for initialization
    void Start()
    {
        bossCurrentHealth = bossMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        bossCurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        bossCurrentHealth = bossMaxHealth;
    }
}
