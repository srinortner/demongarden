using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isDead;
    public int health;
    public int damage;
    public bool dealsDamage;

    public void setToDead()
    {
        isDead = true;
    }

    public bool getIsDead()
    {
        return isDead;
    }

    void Start()
    {

        dealsDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
