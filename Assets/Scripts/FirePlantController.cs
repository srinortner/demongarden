using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This plant only deals damage when fire is emitting from it
public class FirePlantController : PlantController
{

    public float fireTimer;
    private ParticleSystem fire;
    private float fireTimerDefault;
    
    void Start()
    {
        fire = GetComponent<ParticleSystem>();
        fire.Stop();
        fireTimerDefault = fireTimer;
    }
    
    void Update()
    {
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0.0f)
        {
            if (fire.isStopped)
            {
                fire.Play();
                fireTimer = fireTimerDefault;
                dealsDamage = true;
            }
            else
            {
                fire.Stop();
                fireTimer = fireTimerDefault;
                dealsDamage = false;
            }
        }
    }
}
