using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Start()
    {
        // Initialize offset based on initial positions
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Update camera position to follow the player without rotation
        transform.position = player.position + offset;
    }
}
