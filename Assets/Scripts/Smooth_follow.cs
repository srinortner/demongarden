using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smooth_follow : MonoBehaviour
{

    public Transform target;

    private float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.LookAt(target.position + Vector3.up * 2f);
    }
}
