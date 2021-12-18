using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int health;

    private bool isDead;
    private Text playerText;

    private ParticleSystem blood;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        blood = GetComponent<ParticleSystem>();
        blood.Stop();
        playerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (isDead)
        {
            playerText.text = "YOU ARE DEAD!   R - Restart";
            playerText.enabled = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Devil"))
        {
            print("Player collides with Devil");
            GameObject devil = GameObject.Find("Devil");
            DevilController ds = devil.GetComponent<DevilController>();
            int takenDamage = ds.damage;
            health -= takenDamage;
            if (health <= 0)
            {
                isDead = true;
                blood.Play();
                print("Player is dead!");
                
            }
        }

        if (other.tag.Equals("Plant"))
        {
            print("Player collides with Plant");
            GameObject plant = GameObject.Find("Rafflesia1");
            PlantCollision ds = plant.GetComponent<PlantCollision>();
            int takenDamage = ds.damage;
            health -= takenDamage;
            if (health <= 0)
            {
                isDead = true;
                blood.Play();
                print("Player is dead!");
                
            }
        }
    }
    
}
