using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour
{
    public float topXLimit = 300f;
    public float bottomXLimit = 40f;
    public float bottomYLimit = 90f;
    public float topYLimit = 100f;

    private float camRayLength = 20f;
    private LayerMask hitMask;

    private Vector3 finalAngle;

    void Awake()
    {
        hitMask = LayerMask.GetMask("CamHit");
        finalAngle = new Vector3(0f, 0f, 0f);
    }

    void FixedUpdate()
    {
    }

    void LateUpdate()
    {
        TurnArm();
    }

    void TurnArm()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit camHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out camHit, camRayLength, hitMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 armToMouse = camHit.point - transform.position;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(armToMouse);
            Vector3 rawAngle = newRotation.eulerAngles;
            if (rawAngle.x > 180f)
            {
                finalAngle.x = Mathf.Clamp(rawAngle.x, topXLimit, 360f);
            }
            else
            {
                finalAngle.x = Mathf.Clamp(rawAngle.x, 0, bottomXLimit);
            }
            
            finalAngle.y = Mathf.Clamp(rawAngle.y, bottomYLimit, topYLimit);
            finalAngle.z = rawAngle.z;
            newRotation = Quaternion.Euler(finalAngle);
            transform.rotation = newRotation;
        }
    }
}
