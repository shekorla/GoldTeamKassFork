using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float cameraHeight = 10f; // Height of the camera above the player

    void LateUpdate()
    {
        // Check if the player reference is set
        if (player != null)
        {
            // Update the camera's position to be above the player
            transform.position = new Vector3(player.position.x, player.position.y + cameraHeight, player.position.z);

            // Make the camera look at the player
            transform.LookAt(player);
        }
    }
}