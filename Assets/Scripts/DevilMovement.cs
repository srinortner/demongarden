using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilMovement : MonoBehaviour
{
    
    public Transform target;
    public float speed;
    public bool isMoving = false;
    private Vector3 scale;

    public float timeUntilSpawningSeconds = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        scale = this.transform.localScale;
        this.transform.localScale = new Vector3(0.0f,0.0f,0.0f);
        GetComponentInChildren<ParticleSystem>().Stop();
        
    }

    // Update is called once per frame

        void Update()
        {
            timeUntilSpawningSeconds -= Time.deltaTime;
            if (timeUntilSpawningSeconds <= 0.0f)
            {
                this.transform.localScale = scale;
                GetComponentInChildren<ParticleSystem>().Play();
                isMoving = true;
            }

            if(isMoving && (System.Math.Abs(target.position.z - transform.position.z) > 4.5f))
            {
            
                Vector3 currentTarget = new Vector3(target.position.x, transform.position.y, target.position.z);
                transform.position = Vector3
                    .MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
            }
        }

        public void MoveToPlayer(Transform player)
        {
            target = player;
            isMoving = true;
        }

        
    }

