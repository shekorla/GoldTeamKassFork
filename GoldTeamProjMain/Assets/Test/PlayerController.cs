using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the player

    void Update()
    {
        // Get the horizontal and vertical input values
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the movement direction based on input
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // Normalize the movement vector to ensure consistent speed in all directions
        movement.Normalize();

        // Move the player based on the input direction
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}