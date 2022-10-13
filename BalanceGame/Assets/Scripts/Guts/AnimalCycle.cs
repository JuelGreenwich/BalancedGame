using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCycle : MonoBehaviour
{
    public bool isAlive = true;
    [SerializeField] float health = 100;
    [SerializeField] float hungerRate = 0.83f;
    float animalFull = 0;
    bool hasEaten = false;

    void Start()
    {
        InvokeRepeating("AnimalHealth", 1f, 1f);
    }
    private void Update()
    {
        if(health <= 0)
        {
            Death();
        }
        print(health);
    }

    public void Death()
    {
        isAlive = false;
        gameObject.SetActive(false);
    }

    void AnimalHealth()
    {
        health -= hungerRate;
    }

    void AnimalHunger()
    {
        if(hasEaten)
        {
            hungerRate = animalFull;
        }
    }

}
