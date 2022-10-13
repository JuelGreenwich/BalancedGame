using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] GameObject rabbit;
    [SerializeField] GameObject fox;
    [SerializeField] GameObject eagle;
    [SerializeField] AnimalCounter animalCounter;
    [SerializeField] List<Transform> spawnPoints;

    List<GameObject> newRabbits = new List<GameObject>();
    List<GameObject> newFoxes = new List<GameObject>();
    List<GameObject> newEagles = new List<GameObject>();
    GameObject newRabbit;
    GameObject newFox;
    GameObject newEagle;



    void Update()
    {
        RemoveRabbitOnDeath();
        RemoveFoxOnDeath();
        RemoveEagleOnDeath();
    }

    public void AddRabbit()
    {
        newRabbit = Instantiate(rabbit, spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);
        animalCounter.GetComponent<AnimalCounter>().rabbits.Add(newRabbit);
        newRabbits.Add(newRabbit);
    }

    public void AddFox() 
    {
        newFox = Instantiate(fox, spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);
        animalCounter.GetComponent<AnimalCounter>().foxes.Add(newFox);
        newFoxes.Add(newFox);
    }

    public void AddEagle()
    {
        newEagle = Instantiate(eagle, spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);
        animalCounter.GetComponent<AnimalCounter>().eagles.Add(newEagle);
        newEagles.Add(newEagle);
    }

    public void RemoveRabbitOnDeath()
    {
        for (int i = 0; i < newRabbits.Count; i++)
        {
            if (newRabbits[i] != null && newRabbits[i].GetComponent<AnimalCycle>().isAlive == false)
            {
                animalCounter.GetComponent<AnimalCounter>().rabbits.Remove(newRabbits[i]);
            }
        }
    }
    
    public void RemoveFoxOnDeath()
    {
        for (int i = 0; i < newFoxes.Count; i++)
        {
            if (newFoxes[i] != null && newFoxes[i].GetComponent<AnimalCycle>().isAlive == false)
            {
                animalCounter.GetComponent<AnimalCounter>().foxes.Remove(newFoxes[i]);
            }
        }
    }
    public void RemoveEagleOnDeath()
    {
        for (int i = 0; i < newEagles.Count; i++)
        {
            if (newEagles[i] != null && newEagles[i].GetComponent<AnimalCycle>().isAlive == false)
            {
                animalCounter.GetComponent<AnimalCounter>().eagles.Remove(newEagles[i]);
            }
        }
    }
}