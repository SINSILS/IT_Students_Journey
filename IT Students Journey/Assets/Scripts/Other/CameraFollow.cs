using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform student;
    float followSpeed = 10f;
    float liftAmount = 3.3f;
    float liftFrom = 7f;
    private Vector3 startingPosition;

    void Start()
    {
        // Save the starting position of the camera
        startingPosition = transform.position;
    }

    void LateUpdate()
    {
        // If the student is above the lift threshold, follow it and Y axis
        if (student.position.y > liftFrom)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(startingPosition.x, liftAmount, transform.position.z), Time.deltaTime * followSpeed);
        }
        // When student is below the lift threshold, move the camera back to its starting position
        else
        {
            transform.position = Vector3.Lerp(transform.position, startingPosition, Time.deltaTime * followSpeed);
        }
    }
}