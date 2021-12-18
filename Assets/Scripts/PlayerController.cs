using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int health;

    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
                print("Player is dead!");
            }
        }
    }
    
}
