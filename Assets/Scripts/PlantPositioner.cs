using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlantPositioner : MonoBehaviour
{
    public AudioSource positioning;
    public List<GameObject> plantsAvailableForPlacement;
    int currentPlantIndex;

    private bool keydown;
    // Start is called before the first frame update
    void Start()
    {
        GameObject plant00 = (GameObject)Resources.Load("Prefabs/Plant00", typeof(GameObject));
        GameObject plant01 = (GameObject)Resources.Load("Prefabs/Plant01", typeof(GameObject));
        plantsAvailableForPlacement.Add(plant00);
        plantsAvailableForPlacement.Add(plant01);
        currentPlantIndex = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentPlantIndex < plantsAvailableForPlacement.Count-1)
            {
                currentPlantIndex += 1;
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
            
            if (spaceIsEmpty(spawnPosition))
            {
                positioning.Play();
                keydown = true;
                GameObject current = Instantiate(plantsAvailableForPlacement[currentPlantIndex],spawnPosition, Quaternion.identity);
                PlantCollision ds = current.GetComponentInChildren<PlantCollision>();
                ds.damage = 10;
                ds.health = 100;
            }
        }
        else
        {
            keydown = false;
        }
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
