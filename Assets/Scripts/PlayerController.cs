using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int health;

    public bool isDead;
    private Text playerText;
    private string PlayerTextTag = "WaterText";
    private float timeStart = 0;
    Stopwatch stopwatch = new Stopwatch();

    private ParticleSystem blood;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        blood = GetComponent<ParticleSystem>();
        blood.Stop();
        playerText = GameObject.FindWithTag(PlayerTextTag).GetComponent<Text>();
        stopwatch.Start();
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
            stopwatch.Stop();
            long seconds = stopwatch.ElapsedMilliseconds / 1000;
            CrossSceneInformation.secondsSurvived = seconds.ToString();
            playerText.text = "YOU ARE DEAD!";
            playerText.enabled = true;
            waitWhileBleeding();


        }
        

    }

    private void waitWhileBleeding()
    {
        StartCoroutine(waiter());
    }
    
            
        
    IEnumerator waiter()
    {
        //Wait for 2 seconds
        yield return new WaitForSeconds(3);
        
        SceneManager.LoadScene("EndScreen");

    }
    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Devil"))
        {
            print("Player collides with Devil");
            GameObject devil = GameObject.FindWithTag("Devil");
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
            GameObject plant = other.gameObject;
            PlantController ds = plant.GetComponent<PlantController>();
            int takenDamage = ds.damage;
            if (ds.dealsDamage)
            {
                health -= takenDamage;
            }
            if (health <= 0)
            {
                isDead = true;
                blood.Play();
                print("Player is dead!");
                
            }
        }
    }
    
}
