using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;

public class HidingSpot : MonoBehaviour
{
    private bool toggleObject = false;

    [SerializeField]
    private GameObject hidingSpot;
    private GameObject hidingSpotClone;
    private GameObject rabbit;
    private int spotsCreated;

    //Temporarely serialized for testing purposes
    [SerializeField]
    private bool leaveTheSpot = false;

    //on collision disable 2 objects and create an instance of the third object. In theory, when rabbit touches the hiding spot, both rabbit and hiding spot will be temporarely disabled and new instance of a hiding spot with the rabbit texture inside will be placed there
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rabbit")
        {
            print("Collision with the rabbit");
            if (spotsCreated < 1)
            {
                spotsCreated += 1;
                rabbit = collision.gameObject;
                collision.gameObject.SetActive(toggleObject);
                hidingSpotClone = Instantiate(hidingSpot);
                hidingSpotClone.transform.position = gameObject.transform.position;
            }

        }
    }
    private void Update()
    {
        //On leaveTheSpot triggers a script re enabling the rabbit and original hiding spot while destoying the temporary object of hiding spot + rabbit
        if (leaveTheSpot == true)
        {
            rabbit.gameObject.SetActive(!toggleObject);
            Destroy(hidingSpotClone);
            gameObject.SetActive(!toggleObject);
            leaveTheSpot = false;
            spotsCreated = 0;
        }
    }
}