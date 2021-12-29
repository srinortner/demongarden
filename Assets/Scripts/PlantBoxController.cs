using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantBoxController : MonoBehaviour
{
    private Text text;
    private bool plantIsWatered;
    private float waterTimer;

    private bool playerClose;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        text = player.GetComponentInChildren<Text>();
        plantIsWatered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerClose && Input.GetKeyDown(KeyCode.Q))
        {
            waterPlant();
            print("water plant");
            plantIsWatered = true;
            waterTimer = 60.0f;
        }

        if (plantIsWatered)
        {
            waterTimer -= Time.deltaTime;
            if (waterTimer <= 0)
            {
                plantIsWatered = false;
                GetComponent<Renderer>().material.SetColor("_Color", new Color(0.1f, 0.7f, 0.03f, 1.0f));
            }
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

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            text.enabled = false;
            playerClose = false;
        }
    }

    private void waterPlant()
    {
        GetComponent<Renderer>().material.SetColor("_Color", new Color(0.2f, 0.15f, 0.09f, 1.0f));
    }
}