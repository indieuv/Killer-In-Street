using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    private Vector3 velocity;
    private float smoothTime = 0.5f;

   void LateUpdate(){
        Vector3 centerPoint = target.position;
        Vector3 adjustedPos = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, adjustedPos, ref velocity, smoothTime);
   }
}
