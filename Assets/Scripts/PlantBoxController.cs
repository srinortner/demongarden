using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantBoxController : MonoBehaviour
{
    private float timeWithoutWaterLeft;
    private bool plantIsWatered;
    public float timePlantCanLiveWithoutWater;
    private bool playerClose;
    private Text text;
    private float timeUntilWaterNeeded;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        text = player.GetComponentInChildren<Text>();
        plantIsWatered = false;
        timeWithoutWaterLeft = timePlantCanLiveWithoutWater;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerClose && Input.GetKeyDown(KeyCode.Q))
        {
            waterPlant();
            print("water plant");
            plantIsWatered = true;
            timeUntilWaterNeeded = timePlantCanLiveWithoutWater;
        }

        if (plantIsWatered)
        {
            timeUntilWaterNeeded -= Time.deltaTime;
            
            if (timeUntilWaterNeeded <= 0)
            {
                timeWithoutWaterLeft = timePlantCanLiveWithoutWater; //reset buffer timer
                plantIsWatered = false;
                GetComponent<Renderer>().material.SetColor("_Color", new Color(0.1f, 0.07f, 0.03f, 1.0f));
            }
        } else
        { // plant wasn't watered
            //print("Plant needs water..."); //TODO: better feedback than just console text needed!
            timeWithoutWaterLeft -= Time.deltaTime; //time buffer so user has some time before it actually disappears

            if (timeWithoutWaterLeft <= 0)
            {
                GetComponentInChildren<PlantController>().setToDead();
                print("Plant died...");
                Destroy(this.gameObject);
            } else if (timeWithoutWaterLeft > 0.0f && timeWithoutWaterLeft <= (timePlantCanLiveWithoutWater/3))
            {
                GetComponent<Renderer>().material.SetColor("_Color", new Color(0.0f, 0.0f, 0.0f, 0.0f));
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            text.enabled = false;
            playerClose = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            text.enabled = true;
            playerClose = true;
        }
    }

    private void waterPlant()
    {
        GetComponent<Renderer>().material.SetColor("_Color", new Color(0.2f, 0.15f, 0.09f, 1.0f));
    }
}