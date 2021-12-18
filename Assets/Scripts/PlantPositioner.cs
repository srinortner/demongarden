using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlantPositioner : MonoBehaviour
{
    public GameObject plant;
    public AudioSource positioning;

    private bool keydown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            positioning.Play();
            keydown = true;
            Instantiate(plant, new Vector3(Camera.main.transform.position.x, 0.125f, Camera.main.transform.position.z+ 10.5f), Quaternion.identity);
            PlantBoxCollision ds = plant.GetComponent<PlantBoxCollision>();
            ds.damage = 10;
            ds.health = 100;
        }
        else
        {
            keydown = false;
        }
    }
}
