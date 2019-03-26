using UnityEngine;

public class Camera_Follow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed;
    public Vector3 offset;

    void FixedUpdate()
    {
       cameraFollow();
        
    }

    void cameraFollow(){
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }

}