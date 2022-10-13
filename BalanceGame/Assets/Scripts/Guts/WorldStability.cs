using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldStability : MonoBehaviour
{
    [SerializeField] AnimalCounter animalCounter;
    [SerializeField] Slider slider;

    float worldStability;
    float parts;
    float r = 1;
    float f = 5;
    float e = 10;
    float newR;
    float newF;
    float newE;
    float wsSquared;

    void Update()
    {
        //StabiltiyCalculator();
        StabilityCalculatorV2();
    }

    void StabiltiyCalculator()
    {

        newR = animalCounter.GetComponent<AnimalCounter>().rabbits.Count;
        newF = animalCounter.GetComponent<AnimalCounter>().foxes.Count;
        newE = animalCounter.GetComponent<AnimalCounter>().eagles.Count;
        
        parts = 1 / ((newR * r) + (newF * f) + (newE * e));
        
        newR *= parts;
        newF *= parts;
        newE *= parts;
        
        worldStability = newR + newF + newE;
       
        print(worldStability);

        if(float.IsNaN(worldStability))
        {
            return;
        }
        
        slider.value = worldStability;
    }

    void StabilityCalculatorV2()
    {
        newR = animalCounter.GetComponent<AnimalCounter>().rabbits.Count;
        newF = animalCounter.GetComponent<AnimalCounter>().foxes.Count;
        newE = animalCounter.GetComponent<AnimalCounter>().eagles.Count;

        parts = 1 / ((newR * r) + (newF * f) + (newE * e));

        newR *= parts;
        newF *= parts;
        newE *= parts;

        worldStability = newR + newF + newE;

        print(worldStability);

        if (float.IsNaN(worldStability))
        {
            return;
        }

        wsSquared = worldStability * worldStability;
        slider.value = 4 *(-wsSquared + worldStability);

        //print("x = " + worldStability);
        //print("y = " + slider.value);

        // y = 4(-x^2 + x)
    }

    void Parabola()
    {
        worldStability *= worldStability;
        slider.value = 4 * worldStability;
    }

}
