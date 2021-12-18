using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilController : MonoBehaviour
{
    public int health;
    public int damage;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Plant"))
        {
            print("Player collides with Devil");
            GameObject plant = GameObject.Find("Rafflesia1");
            PlantCollision ds = plant.GetComponent<PlantCollision>();
            int takenDamage = ds.damage;
            health -= takenDamage;
            if (health <= 0)
            {
                isDead = true;
                print("Devil is dead!");

            }
        }
    }
}
