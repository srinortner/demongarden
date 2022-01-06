using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilController : MonoBehaviour
{
    public int health;
    public int damage;

    private bool isDead;
    private int worthInPlants;

    // Start is called before the first frame update
    void Start()
    {
        worthInPlants = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            GameObject player = GameObject.Find("Player");
            PlantPositioner plantPositioner = player.GetComponent<PlantPositioner>();
            plantPositioner.numberOfPlantsPlaceable = plantPositioner.numberOfPlantsPlaceable + worthInPlants;
            plantPositioner.displayNewNumberOfPlaceablePlants();
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Plant"))
        {
            print("Plant collides with Devil");
            GameObject plant = GameObject.Find("Rafflesia1");
            PlantController ds = plant.GetComponent<PlantController>();
            int takenDamage = ds.damage;
            if (ds.dealsDamage)
            {
                health -= takenDamage;
            }
            if (health <= 0)
            {
                isDead = true;
                print("Devil is dead!");

            }
        }
        if (other.tag.Equals("House"))
        {
            print("Devil collides with House");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController pc = player.GetComponent<PlayerController>();
            pc.isDead = true;    
            print("Player is dead! Devil reached the house :D");
           
        }
    }
}
