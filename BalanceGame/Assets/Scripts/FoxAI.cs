using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoxAI : MonoBehaviour
{

    private float distanceToFood;
    private bool isBusy;
    private float health;
    private float maxHealth;
    private GameObject food = null;

    [SerializeField]
    private float healthDegen = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsFood();
    }




    private void MoveTowardsFood()
    {
        GameObject[] foodSources;
        foodSources = GameObject.FindGameObjectsWithTag("Rabbit");


        Vector3 position = transform.position;

        if (isBusy == false);
        {
            foreach (GameObject source in foodSources)
            {
                Vector3 distance = source.transform.position - position;
                float squaredDistance = distance.sqrMagnitude;

                if (squaredDistance > distanceToFood)
                {
                    food = source;
                    distanceToFood = squaredDistance;

                }
            }
            isBusy = true;

        }
        if (isBusy == true)

        {
            NavMeshAgent navAgent = GetComponent<NavMeshAgent>();

            navAgent.destination = food.transform.position;
        }
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rabbit")
        {
            Destroy(collision.gameObject);
            isBusy = false;
        }
    }


    void HealthDegen()
    {
        health = health - healthDegen;
    }
}