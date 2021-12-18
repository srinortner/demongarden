using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantBoxCollision : MonoBehaviour
{
    private Text text;
    private bool isDead;
    public int health;
    public int damage;

    private bool playerClose;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        text = player.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerClose && Input.GetKeyDown(KeyCode.Q))
        {
            waterPlant();
            print("water plant");
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
        GetComponent<Renderer>().material.SetColor("_Color", new Color(0.2f,0.15f,0.09f,1.0f));
    }
}
