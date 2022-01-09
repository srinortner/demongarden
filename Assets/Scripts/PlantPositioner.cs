using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlantPositioner : MonoBehaviour
{
    public AudioSource positioning;
    public List<GameObject> plantsAvailableForPlacement;
    public int currentPlantIndex;
    public int numberOfPlantsPlaceable;
    private Text plantCounterText;
    private Text nameText;

    private string nameTextDefault = "Plants left:                      ";

    private bool keydown;
    // Start is called before the first frame update
    void Start()
    {
        GameObject plant00 = (GameObject)Resources.Load("Prefabs/Plant00", typeof(GameObject));
        GameObject plant01 = (GameObject)Resources.Load("Prefabs/Plant01", typeof(GameObject));
        plantsAvailableForPlacement.Add(plant00);
        plantsAvailableForPlacement.Add(plant01);
        currentPlantIndex = 0;
        plantCounterText = GameObject.FindWithTag("PlantCounter").GetComponent<Text>();
        nameText = GameObject.FindWithTag("NameTag").GetComponent<Text>();
        plantCounterText.enabled = true;
        plantCounterText.text = "                    " + numberOfPlantsPlaceable;
        nameText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentPlantIndex < plantsAvailableForPlacement.Count-1)
            {
                currentPlantIndex = 1;
                print("Current Plant is " + currentPlantIndex);
            }
            else
            {
                currentPlantIndex = 0;
                print("Current Plant is " + currentPlantIndex);
            }
        }

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 spawnPosition = new Vector3(Camera.main.transform.position.x, 0.125f, Camera.main.transform.position.z + 10.5f);
            print(numberOfPlantsPlaceable);
            if (spaceIsEmpty(spawnPosition))
            {
                if (numberOfPlantsPlaceable > 0)
                {
                    nameText.text = nameTextDefault;
                    numberOfPlantsPlaceable -= 1;
                    plantCounterText.text = "                    " + numberOfPlantsPlaceable;
                    positioning.Play();
                    keydown = true;
                    GameObject current = Instantiate(plantsAvailableForPlacement[currentPlantIndex], spawnPosition, Quaternion.identity);
                    PlantController ds = current.GetComponentInChildren<PlantController>();
                    ds.damage = 10;
                    ds.health = 100;
                } else
                {
                    plantCounterText.text = "";
                    plantCounterText.enabled = false;
                    nameText.text = "Max number of plants planted";
                    //print("Max number of plants planted."); //for debug purposes
                }

            } else
            {
                plantCounterText.text = "";
                //plantCounterText.enabled = false;
                nameText.text = "Space is occupied";
            }
        }
        else
        {
            keydown = false;
        }
    }

    public void displayNewNumberOfPlaceablePlants()
    {
        plantCounterText.text = "                    " + numberOfPlantsPlaceable;
    }

    private bool spaceIsEmpty(Vector3 spawnPos)
    {
        float radius = 0.5f;
        LayerMask layerMask = (1 << 6) | (1 << 0);
        Collider[] colliders = Physics.OverlapSphere(spawnPos, radius);
        //colliders[0] is always ground! therefore irrelevant
        if (colliders.Length > 1)
        {
            print("false");
            print(colliders[0].name);
            return false;
        } else {
            print("true");
            return true;
        }
    }
}
