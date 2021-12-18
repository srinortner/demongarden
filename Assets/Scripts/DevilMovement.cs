using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilMovement : MonoBehaviour
{
    
    public Transform target;
    public float speed;
    public bool isMoving = false;

    private float timeUntilSpawningSeconds = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;

    }

    // Update is called once per frame

        void Update()
        {
            timeUntilSpawningSeconds -= Time.deltaTime;
            if (timeUntilSpawningSeconds <= 0.0f)
            {
                isMoving = true;
            }
            if(isMoving && (target.position.x - transform.position.x) > 3.5f)
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

