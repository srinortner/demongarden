using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform referenceTransform;
    public float collisionOffset = 0.3f; //To prevent Camera from clipping through Objects
    public float cameraSpeed = 15f; //How fast the Camera should snap into position if there are no obstacles

    Vector3 defaultPos;
    Vector3 directionNormalized;
    Transform parentTransform;
    float defaultDistance;

    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.localPosition; // camera
        //print("defaultPos: " + defaultPos);
        directionNormalized = defaultPos.normalized;
        parentTransform = transform.parent; // player
        //print("parentTransform: " + parentTransform.position);
        defaultDistance = Vector3.Distance(defaultPos, Vector3.zero);
        //print("defaultDistance: " + defaultDistance);

        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // LateUpdate is called after Update
    void LateUpdate()
    {
        Vector3 currentPos = defaultPos;
        RaycastHit hit;
        Vector3 dirTmp = parentTransform.TransformPoint(defaultPos) - referenceTransform.position;
        //print("dirTmp: " + dirTmp);
        if (Physics.SphereCast(parentTransform.position, collisionOffset, dirTmp, out hit, defaultDistance))
        {
            //print("hit");
            currentPos = (directionNormalized * (hit.distance - collisionOffset));

            transform.localPosition = currentPos;
        }
        else
        {
            //print("no hit");
            transform.localPosition = Vector3.Lerp(transform.localPosition, currentPos, Time.deltaTime * cameraSpeed);
        }
    }
}
