using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    

    private void Start()
    {
        health = 100;
    }

    private void Update()
    {
        int damage = 30;

        if(health < damage)
        {
            health -= damage;

        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }
}
