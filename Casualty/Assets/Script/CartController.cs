using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour
{
    public Transform player; // Reference to the player controller's Transform component
    public Camera mainCamera; // Reference to the main camera
    public float heightOffset = 0.5f; // Offset to adjust the height of the cart

    private Vector3 offset; // Offset between the player and the cart

    private void Start()
    {
        // Calculate the initial offset between the player and the cart
        offset = transform.position - player.position;

        // Disable cart's collider during initialization
        GetComponent<Collider>().enabled = false;
    }

    private void FixedUpdate()
    {
        // Calculate the target position for the cart relative to the camera's forward direction
        Vector3 targetPosition = player.position + mainCamera.transform.forward * offset.magnitude;
        targetPosition.y = player.position.y + heightOffset; // Adjust the height offset

        // Set the cart's position to the target position
        transform.position = targetPosition;
    }

    private void LateUpdate()
    {
        // Enable cart's collider after the cart has moved
        GetComponent<Collider>().enabled = true;
    }
}