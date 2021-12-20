using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilSpawnManager : MonoBehaviour
{
    private GameObject devil;
    private DevilMovement dm;

    // Start is called before the first frame update
    void Start()
    {
        devil = GameObject.Find("Devil2");
        DevilController ds = devil.GetComponent<DevilController>();
        dm = devil.GetComponent<DevilMovement>();
        dm.timeUntilSpawningSeconds = 40.0f;
        ds.damage += 10; //increase damage + health of the devil object
        ds.health += 10;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
